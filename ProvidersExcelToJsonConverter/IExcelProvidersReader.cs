using System.Collections.Generic;

namespace ProvidersExcelToJsonConverter
{
    public interface IExcelProvidersReader
    {
        List<Provider> GetProviderList(string excelFilePath); 
    }
}