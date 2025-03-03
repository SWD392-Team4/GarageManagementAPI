using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;


namespace GarageManagementAPI.Shared.ErrorsConstant.SupplierContact
{
    public class SupplierContactErrors
    {
        #region Supplier const errors
        public const string SupplierNotFound = "Supplier contact with id {0} doesn't exist.";
        public const string SupplierName = "Supplier contact with name {0} already existed.";
        public const string SupplierHaveFullContactAlreadyExist = "Supplier with name {0} and contact {1} already existed.";
        #endregion
        public static ErrorsResult GetSupplierNotFoundError() =>
            new()
            {
                Code = nameof(SupplierNotFound),
                Description = SupplierNotFound
            };
        public static ErrorsResult GetSupplierNotFoundWithIdError(Guid supplierId) =>
            new()
            {
                Code = nameof(SupplierNotFound),
                Description = string.Format(SupplierNotFound, supplierId)
            };
        public static ErrorsResult GetSupplierAlreadyExistError(SupplierContactDtoForCreation supplierDto)
        {
            string fullContact = string.Join(", ",
                supplierDto.ContactEmail,
                supplierDto.ContactPhoneNumber
                ).TrimEnd();

            return new()
            {
                Code = nameof(SupplierHaveFullContactAlreadyExist),
                Description = string.Format(SupplierHaveFullContactAlreadyExist, supplierDto.ContactPersonName, fullContact)
            };
        }

        public static ErrorsResult GetSupplierAlreadyExistError(SupplierContactDtoForUpdate supplierDto)
        {
            string fullContact = string.Join(", ",
                supplierDto.ContactEmail,
                supplierDto.ContactPhoneNumber
                ).TrimEnd();

            return new()
            {
                Code = nameof(SupplierHaveFullContactAlreadyExist),
                Description = string.Format(SupplierHaveFullContactAlreadyExist, supplierDto.ContactPersonName, fullContact)
            };
        }
    }
}
