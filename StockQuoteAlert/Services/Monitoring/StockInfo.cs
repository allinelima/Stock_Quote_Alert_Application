namespace StockQuoteAlert.Services.Monitoring
{
    public class StockInfo
    {
        public string Ativo { get; }
        public string Action { get; }
        public decimal Price { get; }

        public StockInfo(string ativo, string action, decimal price)
        {
            Ativo = ativo;
            Action = action;
            Price = price;
        }
    }
}
