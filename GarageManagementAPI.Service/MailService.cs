using GarageManagementAPI.Entities.ConfigurationModels;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Utilities;
using GarageManagementAPI.Shared.DataTransferObjects;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace GarageManagementAPI.Service
{
    public class MailService : IMailService
    {
        public readonly MailConfiguration _mail;
        public const string ConfirmEmail = "Confirm your email.";
        public const string ForgotPassword = "Forgot password.";


        public MailService(IOptionsSnapshot<MailConfiguration> mailConfiguration)
        {
            _mail = mailConfiguration.Value;
        }

        public async Task<bool> SendMail(MailData Mail_Data)
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
                emailBodyBuilder.HtmlBody = Mail_Data.EmailBody;
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                SmtpClient MailClient = new SmtpClient();
                await MailClient.ConnectAsync(_mail.Host, (int)_mail.Port!, SecureSocketOptions.StartTls);
                await MailClient.AuthenticateAsync(_mail.EmailId, _mail.Password);
                await MailClient.SendAsync(email_Message);
                await MailClient.DisconnectAsync(true);
                MailClient.Dispose();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendConfirmEmailEmail(string ToEmail, string url)
        {
            MailData mailData = new MailData()
            {
                EmailSubject = ConfirmEmail,
                EmailBody = MailHelper.ConfirmEmailTemplate(url),
                EmailToId = ToEmail,
            };
            return await SendMail(mailData);
        }

        public async Task<bool> SendForgotPasswordEmail(string ToEmail, string url)
        {
            MailData mailData = new MailData()
            {
                EmailSubject = ForgotPassword,
                EmailBody = MailHelper.ForgotPasswordTemplate(url),
                EmailToId = ToEmail,
            };
            return await SendMail(mailData);
        }



        public async Task<bool> SendConfirmEmailEmployeeEmail(UserForRegistrationEmployeeDto userForRegistrationEmployeeDto, string url)
        {
            string fullname = $"{userForRegistrationEmployeeDto.LastName} {userForRegistrationEmployeeDto.FirstName}";
            MailData mailData = new MailData()
            {
                EmailSubject = ConfirmEmail,
                EmailBody = MailHelper.ConfirmEmailEmployeeTemplate(fullname, userForRegistrationEmployeeDto.UserName!, userForRegistrationEmployeeDto.Password!, url),
                EmailToId = userForRegistrationEmployeeDto.Email,
            };
            return await SendMail(mailData);
        }
    }
}
