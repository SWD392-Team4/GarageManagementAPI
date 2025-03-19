using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ServiceHisory
{
    public class ServiceHistoryErrors
    {
        #region Service const errors
        public const string ServiceHistoryNotFoundError = "Service history of service {0} doesn't exist.";
        public const string ServiceHistoryNotFoundWithId = "Service history with id {0} doesn't exist.";
        public const string ServiceHistoryPrice = "Service history with price already existed.";
        public const string ServiceHistoryPriceRequired = "The service price is required.";
        public const string ServiceHistoryStatusRequired = "The service status is required";
        public const string ServiceHistoryStatusInvalid = "Invalid service status.";
        public const string ServicesHistoryFoundNotMatchWithIds = "Service history found not match with list id {0}.)";

        #endregion
        #region static method

        public static ErrorsResult GetServiceHistoryNotFoundError(Guid serviceId) =>
             new()
             {
                 Code = nameof(ServiceHistoryNotFoundError),
                 Description = string.Format(ServiceHistoryNotFoundError, serviceId)
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

        public static ErrorsResult GetServiceHistoryFoundNotMatchWithIdsError(IEnumerable<Guid> ids)
        {
            return new()
            {
                Code = nameof(ServicesHistoryFoundNotMatchWithIds),
                Description = string.Format(ServicesHistoryFoundNotMatchWithIds, string.Join(", ", ids))
            };
        }
        #endregion
    }
}
