using System.Collections.Generic;
using System.Linq;
using LinqToExcel;

namespace ProvidersExcelToJsonConverter
{
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
                    orderby provider.Item_Title 
                    select provider; 
            }
            else
            {
                providers = from provider in excel.Worksheet<Provider>(0)
                    where provider.Item_Title != null && provider.Item_Title != string.Empty
                    orderby provider.Item_Title 
                    select provider;
            }
            return providers.ToList();
        }
    }
}