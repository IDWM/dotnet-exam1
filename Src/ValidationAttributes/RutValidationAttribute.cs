using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace dotnet_exam1.Src.ValidationAttributes
{
    public partial class RutAttribute : ValidationAttribute
    {
        [GeneratedRegex(@"^\d{1,2}\.\d{3}\.\d{3}-[\dkK]$")]
        private static partial Regex RutRegex();

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext
        )
        {
            var rut = value as string;

            if (string.IsNullOrEmpty(rut))
                return new ValidationResult("El RUT es obligatorio.");

            var regex = RutRegex();

            if (!regex.IsMatch(rut))
                return new ValidationResult("El formato del RUT no es válido.");

            return ValidationResult.Success;
        }
    }
}
