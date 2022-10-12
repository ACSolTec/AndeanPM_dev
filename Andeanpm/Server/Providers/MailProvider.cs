using Andeanpm.Shared.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MimeKit.Text;

namespace Andeanpm.Server.Providers
{
    public class MailProvider
    {
        private const string CONTACT_EMAIL = "info@andeanpm.com";
        private const string APPLICATIO_EMAIL = "careers@andeanpm.com";

        private Subscriber subscriber = new();
        private Contact contact = new();
        private Application application = new();


        public bool MailSuscribeCustomer<T>(T model, string link, SmptSettings smtpSettings, IWebHostEnvironment env)
        {
            try
            {
                var message = new MimeMessage();
             
                message.From.Add(new MailboxAddress(smtpSettings.Name, smtpSettings.Username));

                string pathResources = $"{env.ContentRootPath}wwwroot\\assets\\emails";

                string html = string.Empty;

                if (model is Subscriber)
                {
                    string urlSubscriber = $"{link}/subscriber/{subscriber.Email}";

                    subscriber = model as Subscriber;

                    message.To.Add(new MailboxAddress("", subscriber.Email));

                    message.Subject = "Andeanpm | Confirm to subscribe";

                    html = File.ReadAllText($"{pathResources}\\subscription.html");

                    html = html.Replace("{oSubscriber}", $"{urlSubscriber}/{subscriber.Email}/1")
                                .Replace("{oUnsubscriber}", $"{urlSubscriber}/{subscriber.Email}/2");
                }
                if (model is Contact)
                {
                    contact = model as Contact;
                    message.To.Add(new MailboxAddress("", CONTACT_EMAIL));

                    message.Subject = $"Connecting with {contact.Name}";

                    html = File.ReadAllText($"{pathResources}\\contact.html");

                    html = html.Replace("{oName}", contact.Name)
                                .Replace("{oEmail}", contact.Email)
                                .Replace("{oSubject}", contact.Subject)
                                .Replace("{oMsg}", contact.Msg);
                }
                if (model is Application)
                {
                    application = model as Application;

                    message.To.Add(new MailboxAddress("", APPLICATIO_EMAIL));

                    message.Subject = $"{application.Name}'s new application";

                    html = File.ReadAllText($"{pathResources}\\application.html");

                    html = html.Replace("{oName}", application.Name)
                            .Replace("{oPhone}", application.Phone)
                            .Replace("{oEmail}", application.Email)
                            .Replace("{oApply}", application.ApplyFor)
                            .Replace("{oResume}", $"{link}/{application.ResumeId}");
                }

                message.Body = new TextPart(TextFormat.Html) { Text = html };

                using SmtpClient smtpClient = new();
                smtpClient.Connect(smtpSettings.Server.Trim(), smtpSettings.Port);
                smtpClient.Authenticate(smtpSettings.Username.Trim(), smtpSettings.Password.Trim());
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al enviar correo: " + e.Message);
                Console.WriteLine("Error al enviar correo: " + e.StackTrace);
            }

            return false;
        }

    }
}
