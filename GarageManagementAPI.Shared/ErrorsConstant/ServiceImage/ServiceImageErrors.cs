using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ServiceImage
{
    public class ServiceImageErrors
    {
        #region Product const errors
        public const string ServiceImageNotFound = "Serivce image doesn't exist.";
        public const string ServiceImageNotFoundWithId = "Serivce image with id {0} doesn't exist.";
        public const string ServiceImageLink = "Serivce image with link already existed.";
        public const string ServiceImageLinkRequired = "The serivce image link is required.";
        public const string ServiceImageStatusRequired = "The serivce image status is required";
        public const string ServiceImageStatusInvalid = "Invalid serivce image status.";
        #endregion
        #region static method

        public static ErrorsResult GetServiceImageNotFoundError() =>
             new()
             {
                 Code = nameof(ServiceImageNotFound),
                 Description = ServiceImageNotFound
             };
        public static ErrorsResult GetServiceImageNotFoundWithIdError(Guid serviceImageId) =>
             new()
             {
                 Code = nameof(ServiceImageNotFoundWithId),
                 Description = string.Format(ServiceImageNotFoundWithId, serviceImageId)
             };
        #endregion
    }
}
