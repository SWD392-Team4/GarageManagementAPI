using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;

namespace GarageManagementAPI.Shared.ErrorsConstant.Supplier
{
    public class SupplierErrors
    {
        #region Supplier const errors
        public const string SupplierNotFound = "Supplier with id {0} doesn't exist.";
        public const string SupplierName = "Supplier with name already existed.";
        public const string SupplierTaxcode = "Supplier with tax code {0} already existed.";
        public const string NameRequired = "The supplier name is required.";
        public const string SupplierStatusRequired = "The supplier status is required";
        public const string SupplierStatusInvalid = "Invalid supplier status.";
        public const string SupplierHaveFullAdressAlreadyExist = "Supplier with name {0} and address {1} already existed.";
        #endregion

        #region static method
        public static ErrorsResult GetSupplierNotFoundError() =>
            new()
            {
                Code = nameof(SupplierNotFound),
                Description = SupplierNotFound
            };
        public static ErrorsResult GetSupplierNotFoundWithIdError(Guid SupplierId) =>
            new()
            {
                Code = nameof(SupplierNotFound),
                Description = string.Format(SupplierNotFound, SupplierId)
            };
        public static ErrorsResult GetSupplierNameAlreadyExistError(SupplierDtoForCreation supplierDtoForCreation) =>
             new()
             {
                 Code = nameof(SupplierName),
                 Description = string.Format(SupplierName, supplierDtoForCreation.Name)
             };
        public static ErrorsResult GetSupplierNameUpdateAlreadyExistError(SupplierDtoForUpdate supplierDtoForUpdate) =>
             new()
             {
                 Code = nameof(SupplierName),
                 Description = string.Format(SupplierName, supplierDtoForUpdate.Name)
             };

        public static ErrorsResult GetSupplierTaxcodeUpdateAlreadyExistError(string taxcode) =>
       new()
       {
           Code = nameof(SupplierTaxcode),
           Description = string.Format(SupplierTaxcode, taxcode)
       };
        public static ErrorsResult GetSupplierAlreadyExistError(SupplierDtoForCreation supplierDto)
        {
            string fullAddress = string.Join(", ",
                supplierDto.Address,
                supplierDto.Wards,
                supplierDto.District,
                supplierDto.Province).TrimEnd();

            return new()
            {
                Code = nameof(SupplierHaveFullAdressAlreadyExist),
                Description = string.Format(SupplierHaveFullAdressAlreadyExist, supplierDto.Name, fullAddress)
            };
        }

        public static ErrorsResult GetSupplierAlreadyExistError(SupplierDtoForUpdate supplierDto)
        {
            string fullAddress = string.Join(", ",
                supplierDto.Address,
                supplierDto.Wards,
                supplierDto.District,
                supplierDto.Province).TrimEnd();

            return new()
            {
                Code = nameof(SupplierHaveFullAdressAlreadyExist),
                Description = string.Format(SupplierHaveFullAdressAlreadyExist, supplierDto.Name, fullAddress)
            };
        }
        #endregion
    }
}
