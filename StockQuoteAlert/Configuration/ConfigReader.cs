using System;
using System.IO;
using Newtonsoft.Json;
using StockQuoteAlert.Services.Configuration;

namespace StockQuoteAlert.Services.Configuration
{
    public class ConfigReader
    {
        private string configFilePath;

        public ConfigReader(string configFilePath)
        {
            this.configFilePath = configFilePath;
        }

        public dynamic? ReadConfig()
        {
            if (File.Exists(configFilePath))
            {
                try
                {
                    string configJson = File.ReadAllText(configFilePath);
                    return JsonConvert.DeserializeObject<dynamic>(configJson); // Use JsonConvert.DeserializeObject
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao ler o arquivo de configuração: {ex.Message}");
                }
            }

            return null;
        }
    }
}
