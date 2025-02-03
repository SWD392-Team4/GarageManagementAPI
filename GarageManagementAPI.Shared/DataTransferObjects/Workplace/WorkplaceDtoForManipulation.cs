using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Workplace
{
    public record WorkplaceDtoForManipulation
    {
        [Required(ErrorMessage = WorkplaceErrors.NameRequired)]
        public string? Name { get; set; }

        [Required(ErrorMessage = WorkplaceErrors.NameRequired)]
        [RegularExpression(@"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)", ErrorMessage = WorkplaceErrors.PhoneNumberInvalid)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = WorkplaceErrors.AddressRequired)]
        public string? Address { get; set; }

        [Required(ErrorMessage = WorkplaceErrors.ProvinceRequired)]
        public string? Province { get; set; }

        [Required(ErrorMessage = WorkplaceErrors.DistrictRequred)]
        public string? District { get; set; }

        [Required(ErrorMessage = WorkplaceErrors.WardRequired)]
        public string? Ward { get; set; }

        [EnumDataType(typeof(WorkplaceType), ErrorMessage = WorkplaceErrors.WorkplaceTypeInvalid)]
        [Required(ErrorMessage = WorkplaceErrors.WorkplaceTypeRequired)]
        public WorkplaceType WorkplaceType { get; set; }
    }
}
