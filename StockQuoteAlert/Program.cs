using StockQuoteAlert.Services.Monitoring;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Uso: stock-quote-alert.exe [Ativo] [PreçoVenda] [PreçoCompra]");
                return;
            }

            string ativo = args[0];
            if (
                !decimal.TryParse(args[1], out decimal precoVenda)
                || !decimal.TryParse(args[2], out decimal precoCompra)
            )
            {
                Console.WriteLine("Os preços de referência devem ser números válidos.");
                return;
            }

            // Aqui, você pode ler as configurações do arquivo de configuração usando a classe ConfigReader.
            // ConfigReader configReader = new ConfigReader();
            // var smtpSettings = configReader.ReadSmtpSettings();
            // var emailDestination = configReader.ReadEmailDestination();

            // Crie instâncias das outras classes necessárias
            StockMonitor stockMonitor = new StockMonitor(ativo, precoVenda, precoCompra);
            // ApiCaller apiCaller = new ApiCaller();
            // EmailSender emailSender = new EmailSender(smtpSettings);

            // Inicie a aplicação
            _ = stockMonitor.StartMonitoring();
        }
    }
}
