using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StockQuoteAlert.Services.Api;
using StockQuoteAlert.Services.Monitoring;

namespace StockQuoteAlert.Services.Monitoring
{
    public class StockMonitor : IObserver<StockInfo>
    {
        private string Ativo { get; }
        private decimal PrecoCompra { get; }
        private decimal PrecoVenda { get; }
        private List<IObserver<StockInfo>> observers = new List<IObserver<StockInfo>>();

        public StockMonitor(string ativo, decimal precoCompra, decimal precoVenda)
        {
            Ativo = ativo;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
        }

        public async Task StartMonitoring()
        {
            while (true)
            {
                // Aqui você deve chamar a API para obter a cotação atual do ativo
                // Use a classe ApiCaller para buscar a cotação do ativo

                decimal cotacaoAtual = await ApiCaller.GetStockPrice(Ativo);

                // Compare a cotação atual com os preços de referência
                if (cotacaoAtual > PrecoVenda)
                {
                    NotifyObservers("VENDA", cotacaoAtual);
                }
                else if (cotacaoAtual < PrecoCompra)
                {
                    NotifyObservers("COMPRA", cotacaoAtual);
                }

                // Aguarde um intervalo de tempo antes de verificar novamente
                Thread.Sleep(TimeSpan.FromMinutes(5)); // Exemplo: verificação a cada 5 minutos
            }
        }

        public void RegisterObserver(IObserver<StockInfo> observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver<StockInfo> observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string action, decimal newPrice)
        {
            StockInfo stockInfo = new StockInfo(Ativo, action, newPrice);

            foreach (var observer in observers)
            {
                observer.OnNext(stockInfo);
            }
        }

        public void OnCompleted()
        {
            // Lidar com a conclusão da sequência, se necessário
        }

        public void OnError(Exception error)
        {
            // Lidar com erros, se necessário
        }

        public void OnNext(StockInfo value)
        {
            // Lidar com uma atualização do observável, se necessário
        }
    }
}
