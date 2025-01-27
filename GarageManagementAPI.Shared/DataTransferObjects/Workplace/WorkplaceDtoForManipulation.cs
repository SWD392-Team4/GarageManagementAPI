using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Workplace
{
    public record WorkplaceDtoForManipulation
    {
        [Required(ErrorMessage = WorkplaceErros.NameRequired)]
        public string? Name { get; set; }

        [Required(ErrorMessage = WorkplaceErros.NameRequired)]
        [RegularExpression(@"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)", ErrorMessage = WorkplaceErros.PhoneNumberInvalid)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = WorkplaceErros.AddressRequired)]
        public string? Address { get; set; }

        [Required(ErrorMessage = WorkplaceErros.ProvinceRequired)]
        public string? Province { get; set; }

        [Required(ErrorMessage = WorkplaceErros.DistrictRequred)]
        public string? District { get; set; }

        [Required(ErrorMessage = WorkplaceErros.WardRequired)]
        public string? Ward { get; set; }

        [EnumDataType(typeof(WorkplaceType), ErrorMessage = WorkplaceErros.WorkplaceTypeInvalid)]
        [Required(ErrorMessage = WorkplaceErros.WorkplaceTypeRequired)]
        public WorkplaceType WorkplaceType { get; set; }
    }
}
