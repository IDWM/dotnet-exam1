using dotnet_exam1.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_exam1.Src.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
