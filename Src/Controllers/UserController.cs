using dotnet_exam1.Src.DTOs;
using dotnet_exam1.Src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_exam1.Src.Controllers
{
    public class UserController(IUserRepository userRepository, IGenderRepository genderRepository)
        : BaseApiController
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IGenderRepository _genderRepository = genderRepository;

        private readonly string[] _sortOptions = ["asc", "desc"];

        [HttpGet]
        public async Task<IActionResult> GetUsers(
            [FromQuery] string? sort,
            [FromQuery] string? gender
        )
        {
            if (sort is not null)
            {
                sort = sort.ToLower();

                if (!_sortOptions.Contains(sort))
                    return BadRequest("El valor del parámetro 'sort' debe ser 'asc' o 'desc'.");
            }

            if (gender is not null)
            {
                gender = gender.ToLower();

                if (!await _genderRepository.ExistsGender(gender))
                    return BadRequest("El valor del parámetro 'gender' no existe.");
            }

            var users = await _userRepository.GetUsers(sort, gender);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userRepository.GetUserById(id);

            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var rut = createUserDto.Rut;
            if (await _userRepository.GetUserByRut(rut) is not null)
                return Conflict("El RUT ya existe.");

            createUserDto.Gender = createUserDto.Gender.ToLower();
            var gender = createUserDto.Gender;
            if (!await _genderRepository.ExistsGender(gender))
                return BadRequest("El género no existe.");

            var user = await _userRepository.CreateUser(createUserDto);

            return Created($"/api/user/{user.Id}", user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] int id,
            [FromBody] UpdateUserDto updateUserDto
        )
        {
            var user = await _userRepository.GetUserById(id);

            if (user is null)
                return NotFound();

            var rut = updateUserDto.Rut;
            var userSameRut = await _userRepository.GetUserByRut(rut);
            if (userSameRut is not null && userSameRut.Id != id)
                return Conflict("El RUT ya existe.");

            updateUserDto.Gender = updateUserDto.Gender.ToLower();
            var gender = updateUserDto.Gender;
            if (!await _genderRepository.ExistsGender(gender))
                return BadRequest("El género no existe.");

            var updatedUser = await _userRepository.UpdateUser(id, updateUserDto);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user is null)
                return NotFound();

            var deletedUser = await _userRepository.DeleteUser(id);

            return Ok(deletedUser);
        }
    }
}
