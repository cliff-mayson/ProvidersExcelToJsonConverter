using System;
using System.IO;
using Newtonsoft.Json;

namespace ProvidersExcelToJsonConverter
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args != null && args[0] != null)
            {
                var fullFileString = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), args[0]);
                var outputFileName = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), "providers.json");

                try
                {
                    var reader = new LinqExcelProvidersReader();
                    var providers = reader.GetProviderList(fullFileString);

                    var json = JsonConvert.SerializeObject(providers, Formatting.Indented);

                    File.WriteAllText(outputFileName, json);
                    Console.WriteLine("Conversion completed output to providers.json");
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Failed to convert excel file.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Usage: ProvidersExcelToJsonConverter.exe 'fileName'");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadLine();
            }
        } 
    }
}
