using System.ComponentModel.DataAnnotations;

namespace JWTAndApi.CustomAttributes
{
    public class NotNullAndMaxLength(int maxValue) : ValidationAttribute
    {
        private readonly int _maxValue = maxValue;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string stringValue &&
                (
                    string.IsNullOrEmpty(stringValue) ||
                    stringValue.Length <= _maxValue
                )
                )
                return ValidationResult.Success;

            return new ValidationResult($"{_maxValue} karakter sayısını aştınız");
        }
    }
}
