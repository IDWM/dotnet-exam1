using System.Text.Json;
using dotnet_exam1.Src.DTOs;
using dotnet_exam1.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_exam1.Src.Data.Seed
{
    public static class Seeder
    {
        private static readonly JsonSerializerOptions _options =
            new() { PropertyNameCaseInsensitive = true };

        public static async Task Seed(DataContext context)
        {
            await SeedGenders(context);
            await SeedUsers(context);
        }

        public static async Task SeedGenders(DataContext dataContext)
        {
            if (dataContext.Genders.Any())
                return;

            var gendersData = await File.ReadAllTextAsync("Src/Data/Seed/genders.json");

            var genders = JsonSerializer.Deserialize<List<Gender>>(gendersData, _options);

            if (genders is null)
                return;

            await dataContext.AddRangeAsync(genders);
            await dataContext.SaveChangesAsync();
        }

        public static async Task SeedUsers(DataContext dataContext)
        {
            if (dataContext.Users.Any())
                return;

            var usersData = await File.ReadAllTextAsync("Src/Data/Seed/users.json");
            var usersDto = JsonSerializer.Deserialize<List<CreateUserDto>>(usersData, _options);

            if (usersDto is null)
                return;

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var gender = await dataContext.Genders.FirstOrDefaultAsync(g =>
                    g.Name == userDto.Gender
                );

                if (gender is null)
                    continue;

                var user = new User
                {
                    Rut = userDto.Rut,
                    Email = userDto.Email,
                    Birthdate = userDto.Birthdate,
                    Gender = gender
                };

                users.Add(user);
            }

            await dataContext.AddRangeAsync(users);
            await dataContext.SaveChangesAsync();
        }
    }
}
