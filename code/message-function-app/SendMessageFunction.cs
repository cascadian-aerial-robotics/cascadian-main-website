using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Grump.Azure;
using Newtonsoft.Json;
using Cascadian.Website.Abstractions;
using System.Net.Mail;
using System.Net;

namespace message_function_app
{
    public static class SendMessageFunction
    {
        [FunctionName("send-message")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            try
            {
                // Gets configuration
                var config = new ConfigurationBuilder().SetBasePath(context.FunctionAppDirectory).AddJsonFile("azure.settings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables().Build();
                var smtpServer = config["SmtpConfiguration:server"];
                var port = int.Parse(config["SmtpConfiguration:port"]);
                var userName = config["SmtpConfiguration:username"];

                // Gets secrets manager and smtp password.
                var secretsProvider = new KeyVaultSecretsProvider(config);
                var smtpPassword = await secretsProvider.GetSecretAsync("SmtpPassword");

                // Gets the message itself.
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var contactMessage = JsonConvert.DeserializeObject<ContactMessage>(requestBody);
                var messageFromName = contactMessage.Name;
                var messageFromEmail = contactMessage.Email;
                var message = contactMessage.Message;

                SendEmail(smtpServer, port, userName, smtpPassword, "noreply@cascadianaerialrobotics.com", "Message Service", "adrian@cascadianaerialrobotics.com", "Adrian Padilla", message, $"Message from {messageFromName} ({messageFromEmail})");

                var greeting = config["Ok_Message"];
                return new OkObjectResult(greeting);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "The message function failed.");
                throw;
            }
        }

        internal static void SendEmail(string smtpClient, int port, string credentialUserName, string credentialPassword, string fromEmail, string fromName, string toEmail, string toName, string body, string subject)
        {
            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient(smtpClient, port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(credentialUserName, credentialPassword)
            };

            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress(fromEmail, fromName, System.Text.Encoding.UTF8);

            // Set destinations for the email message.
            MailAddress to = new MailAddress(toEmail, toName, System.Text.Encoding.UTF8);

            // Specify the message content.
            MailMessage message = new MailMessage(from, to);

            message.Body = body;

            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = false;

            message.Subject = subject;

            client.Send(message);

        }
    }
}
