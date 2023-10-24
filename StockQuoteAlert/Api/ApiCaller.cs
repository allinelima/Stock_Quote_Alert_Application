using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockQuoteAlert.Services.Api
{
    public class ApiCaller
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<decimal> GetStockPrice(string ativo)
        {
            try
            {
                // Substitua esta URL pela URL da API BRAPI com o token apropriado
                string apiUrl = $"https://brapi.dev/api/quote/{ativo}?token=7PxWxG8iyDGWgEAhu1M2Pp";

                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    decimal stockPrice = ParseStockPrice(responseContent);

                    return stockPrice;
                }
                else
                {
                    throw new Exception($"Erro na solicitação à API BRAPI: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter cotação do ativo: {ex.Message}");
                throw;
            }
        }

        private static decimal ParseStockPrice(string responseContent)
        {
            // TODO Implemente a lógica para analisar a resposta da API BRAPI e extrair o preço do ativo.
            // TODO Esta parte específica depende da estrutura da resposta da BRAPI.
            // TODO Exemplo fictício:
            // TODO var jsonData = JsonConvert.DeserializeObject<JObject>(responseContent);
            // TODO decimal stockPrice = jsonData["stockPrice"].Value<decimal>();

            // TODO Substitua esta linha pelo código real de análise da resposta da API BRAPI.
            decimal stockPrice = 100.0m; // Exemplo fictício

            return stockPrice;
        }
    }
}
