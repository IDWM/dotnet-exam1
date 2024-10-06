using System.ComponentModel.DataAnnotations;
using dotnet_exam1.Src.ValidationAttributes;

namespace dotnet_exam1.Src.DTOs
{
    public class UpdateUserDto
    {
        [Rut]
        public required string Rut { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        public required string Gender { get; set; }

        [Birthdate]
        public required DateOnly Birthdate { get; set; }
    }
}
