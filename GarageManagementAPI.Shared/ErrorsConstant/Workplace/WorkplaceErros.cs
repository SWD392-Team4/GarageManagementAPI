using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Workplace
{
    public class WorkplaceErros
    {
        #region Workplace const errors
        public const string WorkplaceNotFound = "Work place with id {0} doesn't exist.";
        public const string WorkplaceHaveFullAdressAlreadyExist = "Workplace with name {0}, phonenumber {1} and address {2} already existed.";
        public const string NameRequired = "The work place name is required.";
        public const string PhoneNumberRequired = "The work place phonenumber is required.";
        public const string PhoneNumberInvalid = "The phone number is invalid. Ensure it is a valid Vietnamese phone number.";
        public const string AddressRequired = "The work place address is required.";
        public const string ProvinceRequired = "The work place province is required.";
        public const string DistrictRequred = "The work place district is required.";
        public const string WardRequired = "The work place ward is required";
        public const string WorkplaceStatusRequired = "The work place status is required";
        public const string WorkplaceStatusInvalid = "Invalid work place status.";
        public const string WorkplaceTypeRequired = "The work place type is required";
        public const string WorkplaceTypeInvalid = "Invalid work place type value.";

        #endregion

        #region static method
        public static ErrorsResult GetWorkplaceNotFoundError(Guid workplaceId) =>
            new()
            {
                Code = nameof(WorkplaceNotFound),
                Description = string.Format(WorkplaceNotFound, workplaceId)
            };

        public static ErrorsResult GetWorkplaceAlreadyExistError(WorkplaceDtoForCreation workplaceDtoForCreation)
        {
            string fullAddress = string.Join(", ",
                workplaceDtoForCreation.Address,
                workplaceDtoForCreation.Ward,
                workplaceDtoForCreation.District,
                workplaceDtoForCreation.Province).TrimEnd();

            return new()
            {
                Code = nameof(WorkplaceHaveFullAdressAlreadyExist),
                Description = string.Format(WorkplaceHaveFullAdressAlreadyExist, workplaceDtoForCreation.Name, workplaceDtoForCreation.PhoneNumber, fullAddress)
            };
        }
        #endregion
    }
}
