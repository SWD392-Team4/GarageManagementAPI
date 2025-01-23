using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.Constant.Garage
{
    public class GarageErrors
    {
        public const string GarageNotFound = "Garage with id {0} doesn't exist.";
        #region garage const errors
        #endregion

        #region static method
        public static ErrorsResult GetGarageNotFoundError(Guid garageId) =>
            new()
            {
                Code = nameof(GarageNotFound),
                Description = string.Format(GarageNotFound, garageId)
            };
        #endregion
    }
}
