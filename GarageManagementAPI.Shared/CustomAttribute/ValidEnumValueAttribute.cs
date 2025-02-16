using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.CustomAttribute
{
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public ValidEnumValueAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Provided type must be an enum.");
            }
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || !System.Enum.IsDefined(_enumType, value))
            {
                return new ValidationResult($"The value '{value}' is not valid for enum '{_enumType.Name}'.");
            }

            return ValidationResult.Success!;
        }
    }
}
