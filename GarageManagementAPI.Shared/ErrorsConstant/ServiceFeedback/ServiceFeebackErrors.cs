using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ServiceFeedback
{
    public class ServiceFeebackErrors
    {
        #region Service const errors
        public const string ServiceFeedbackNotFoundError = "Service feedback with doesn't exist.";
        public const string ServiceFeedbackNotFoundWithId = "Service feedback with id {0} doesn't exist.";
        public const string ServiceFeedbackPrice = "Service feedback with price already existed.";
        public const string ServiceFeedbackStatusRequired = "The service feeback status is required.";
        public const string ServiceFeedbackStatusInvalid = "Invalid service feeback.";
        #endregion
        #region static method

        public static ErrorsResult GetServiceFeedbackNotFoundError() =>
             new()
             {
                 Code = nameof(ServiceFeedbackNotFoundError),
                 Description = ServiceFeedbackNotFoundError
             };
        public static ErrorsResult GetServiceFeedbackNotFoundWithIdError(Guid ServiceId) =>
             new()
             {
                 Code = nameof(ServiceFeedbackNotFoundWithId),
                 Description = string.Format(ServiceFeedbackNotFoundWithId, ServiceId)
             };


        public static ErrorsResult GetServiceFeedbackPriceAlreadyExistError(decimal? price) =>
             new()
             {
                 Code = nameof(ServiceFeedbackPrice),
                 Description = string.Format(ServiceFeedbackPrice, price)
             };
        #endregion
    }
}
