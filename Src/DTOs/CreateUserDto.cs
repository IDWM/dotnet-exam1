using System.ComponentModel.DataAnnotations;
using dotnet_exam1.Src.ValidationAttributes;

namespace dotnet_exam1.Src.DTOs
{
    public class CreateUserDto
    {
        [Rut]
        public required string Rut { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        public required string Gender { get; set; }

        [Birthdate]
        public required DateOnly Birthdate { get; set; }
    }
}
