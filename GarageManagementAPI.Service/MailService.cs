using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace GarageManagementAPI.Service
{
    public class MailService : IMailService
    {
        public readonly MailConfiguration _mail;

        public MailService(IOptionsSnapshot<MailConfiguration> mailConfiguration)
        {
            _mail = mailConfiguration.Value;
        }

        public bool SendMail(MailData Mail_Data)
        {
            try
            {
                //MimeMessage - a class from Mimekit
                MimeMessage email_Message = new MimeMessage();
                MailboxAddress email_From = new MailboxAddress(_mail.Name, _mail.EmailId);
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new MailboxAddress(string.Empty, Mail_Data.EmailToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = Mail_Data.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = Mail_Data.EmailBody;
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                SmtpClient MailClient = new SmtpClient();
                MailClient.Connect(_mail.Host, (int)_mail.Port!, SecureSocketOptions.StartTls);
                MailClient.Authenticate(_mail.EmailId, _mail.Password);
                MailClient.Send(email_Message);
                MailClient.Disconnect(true);
                MailClient.Dispose();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
