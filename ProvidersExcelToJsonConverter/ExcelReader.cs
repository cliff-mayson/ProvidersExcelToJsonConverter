using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using LinqToExcel;

namespace ProvidersExcelToJsonConverter
{
    public interface IExcelProvidersReader
    {
        List<Provider> GetProviderList(string excelFilePath); 
    }

    public class LinqExcelProvidersReader : IExcelProvidersReader
    {
        public List<Provider> GetProviderList(string excelFilePath)
        {
            var excel = new ExcelQueryFactory(excelFilePath);
            var firstRow = excel.WorksheetNoHeader(0).First();
            IOrderedQueryable<Provider> providers;

            if (firstRow[0].Value.ToString() == "Item Title")
            {
                excel.AddMapping<Provider>(provider => provider.Item_Title, "Item Title");
                providers = from provider in excel.Worksheet<Provider>(0)
                            where provider.Item_Title != null && provider.Item_Title != string.Empty
                            orderby provider.Item_Title descending
                            select provider; 
            }
            else
            {
                providers = from provider in excel.Worksheet<Provider>(0)
                            where provider.Item_Title != null && provider.Item_Title != string.Empty
                            orderby provider.Item_Title descending
                            select provider;
            }
            return providers.ToList();
        }
    }

    public class OleDbExcelReader : IExcelProvidersReader
    {
        public List<Provider> GetProviderList(string excelFilePath)
        {
            if (!File.Exists(excelFilePath))
            {
                throw new FileNotFoundException(excelFilePath);
            }
            
            var cnnStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\"", excelFilePath);
            var cnn = new OleDbConnection(cnnStr);

            var dataTable = new DataTable();
            try
            {
                cnn.Open();
                var schemaTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (schemaTable == null)
                {
                    throw new ArgumentException("The worksheet number provided cannot be found in the spreadsheet");
                }
                var worksheet = schemaTable.Rows[0]["table_name"].ToString().Replace("'", "");
                var sql = string.Format("select * from [{0}]", worksheet);
                var dataAdapter = new OleDbDataAdapter(sql, cnn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                // ???
                throw e;
            }
            finally
            {
                // free resources
                cnn.Close();
            }
            return dataTable.DataTableToList<Provider>();
        }
    }

}