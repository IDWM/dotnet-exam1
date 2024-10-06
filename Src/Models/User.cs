using System.ComponentModel.DataAnnotations;
using dotnet_exam1.Src.ValidationAttributes;

namespace dotnet_exam1.Src.Models
{
    public class User
    {
        public int Id { get; set; }

        [Rut]
        public required string Rut { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [Birthdate]
        public required DateOnly Birthdate { get; set; }
        public int GenderId { get; set; }
        public required Gender Gender { get; set; }
    }
}
