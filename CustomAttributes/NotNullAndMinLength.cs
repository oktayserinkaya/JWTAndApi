using System.ComponentModel.DataAnnotations;

namespace JWTAndApi.CustomAttributes
{
    public class NotNullAndMinLength(int minValue) : ValidationAttribute
    {
        private readonly int _minValue = minValue;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string stringValue &&
                (
                    string.IsNullOrEmpty(stringValue) ||
                    stringValue.Length >= _minValue
                )
                )
                return ValidationResult.Success;

            return new ValidationResult($"En az {_minValue} karakter girmelisiniz");
        }
    }
}
