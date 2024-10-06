using AutoMapper;
using dotnet_exam1.Src.Data;
using dotnet_exam1.Src.DTOs;
using dotnet_exam1.Src.Interfaces;
using dotnet_exam1.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_exam1.Src.Repositories
{
    public class UserRepository(DataContext dataContext, IMapper mapper) : IUserRepository
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            var gender =
                await _dataContext.Genders.FirstOrDefaultAsync(g => g.Name == createUserDto.Gender)
                ?? throw new Exception("El género no existe.");

            var user = _mapper.Map<User>(createUserDto);
            user.Gender = gender;
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> DeleteUser(int id)
        {
            var user =
                await _dataContext.Users.FindAsync(id)
                ?? throw new Exception("El usuario no existe.");

            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            var user = await _dataContext
                .Users.Include(u => u.Gender)
                .FirstOrDefaultAsync(u => u.Id == id);
            return user is null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetUserByRut(string rut)
        {
            var user = await _dataContext
                .Users.Include(u => u.Gender)
                .FirstOrDefaultAsync(u => u.Rut == rut);
            return user is null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsers(string? sort, string? gender)
        {
            IQueryable<User> usersQuery = _dataContext.Users;

            if (sort is not null)
                usersQuery = sort switch
                {
                    "asc" => usersQuery.OrderBy(u => u.Name),
                    "desc" => usersQuery.OrderByDescending(u => u.Name),
                    _ => usersQuery
                };

            if (gender is not null)
                usersQuery = usersQuery.Where(u => u.Gender.Name == gender);

            var users = await usersQuery.Include(u => u.Gender).ToListAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var gender =
                await _dataContext.Genders.FirstOrDefaultAsync(g => g.Name == updateUserDto.Gender)
                ?? throw new Exception("El género no existe.");

            var user =
                await _dataContext.Users.Include(u => u.Gender).FirstOrDefaultAsync(u => u.Id == id)
                ?? throw new Exception("El usuario no existe.");

            _mapper.Map(updateUserDto, user);
            user.Gender = gender;
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}
