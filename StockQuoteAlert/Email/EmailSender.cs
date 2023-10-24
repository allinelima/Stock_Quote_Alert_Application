using System;
using System.Net;
using System.Net.Mail;
using StockQuoteAlert.Services.Configuration;

namespace StockQuoteAlert.Services.Email
{
    public class EmailSender
    {
        private readonly SmtpClient smtpClient;

        public EmailSender(SmtpConfig smtpConfig)
        {
            smtpClient = new SmtpClient
            {
                Host = smtpConfig.SmtpServer!,
                Port = smtpConfig.SmtpPort,
                Credentials = new NetworkCredential(smtpConfig.SmtpUsername, smtpConfig.SmtpPassword),
                EnableSsl = true,
            };
        }

        public void SendAlert(string ativo, string action, decimal price)
        {
            string subject = $"Alerta de ação: {ativo} - {action}";
            string body = $"O preço da ação {ativo} atingiu o valor de {price:C}.";

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("seuemail@gmail.com"), // Substitua pelo seu endereço de e-mail
                Subject = subject,
                Body = body,
                IsBodyHtml = false,
            };

            mailMessage.To.Add("destinatario@gmail.com"); // Substitua pelo destinatário real

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-mail de alerta enviado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o e-mail: {ex.Message}");
            }
        }
    }
}
