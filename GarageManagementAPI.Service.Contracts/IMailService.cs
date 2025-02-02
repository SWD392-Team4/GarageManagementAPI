using GarageManagementAPI.Shared.DataTransferObjects;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IMailService
    {
        Task<bool> SendForgotPasswordEmail(string ToEmail, string url);

        Task<bool> SendConfirmEmailEmail(string ToEmail, string url);

        Task<bool> SendMail(MailData Mail_Data);
    }
}
