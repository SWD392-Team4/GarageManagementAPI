using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Brand;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Brand
{
    public record BrandDtoForManipulation
    {
        [Required(ErrorMessage = BrandErrors.NameRequired)]
        public string BrandName { get; set; } = null!;

        public string LinkLogo { get; set; } = null!;
    }
}
