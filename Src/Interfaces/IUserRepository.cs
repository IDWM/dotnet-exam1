using dotnet_exam1.Src.DTOs;

namespace dotnet_exam1.Src.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> CreateUser(CreateUserDto createUserDto);
        Task<UserDto> DeleteUser(int id);
        Task<UserDto?> GetUserById(int id);
        Task<UserDto?> GetUserByRut(string rut);
        Task<IEnumerable<UserDto>> GetUsers(string? sort, string? gender);
        Task<UserDto> UpdateUser(int id, UpdateUserDto updateUserDto);
    }
}
