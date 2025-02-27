using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ServiceHisory
{
    public class ServiceHistoryErrors
    {
        #region Service const errors
        public const string ServiceHistoryNotFoundError = "Service history with doesn't exist.";
        public const string ServiceHistoryNotFoundWithId = "Service history with id {0} doesn't exist.";
        public const string ServiceHistoryPrice = "Service history with price already existed.";
        public const string ServiceHistoryPriceRequired = "The service price is required.";
        public const string ServiceHistoryStatusRequired = "The service status is required";
        public const string ServiceHistoryStatusInvalid = "Invalid service status.";
        #endregion
        #region static method

        public static ErrorsResult GetServiceHistoryNotFoundError() =>
             new()
             {
                 Code = nameof(ServiceHistoryNotFoundError),
                 Description = ServiceHistoryNotFoundError
             };
        public static ErrorsResult GetServiceHistoryNotFoundWithIdError(Guid ServiceId) =>
             new()
             {
                 Code = nameof(ServiceHistoryNotFoundWithId),
                 Description = string.Format(ServiceHistoryNotFoundWithId, ServiceId)
             };


        public static ErrorsResult GetServiceHistoryPriceAlreadyExistError(decimal? price) =>
             new()
             {
                 Code = nameof(ServiceHistoryPrice),
                 Description = string.Format(ServiceHistoryPrice, price)
             };
        #endregion
    }
}
