namespace dotnet_exam1.Src.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<User> Users { get; set; } = [];
    }
}
