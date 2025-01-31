using GarageManagementAPI.Shared.DataTransferObjects;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IMailService
    {
        bool SendMail(MailData Mail_Data);
    }
}
