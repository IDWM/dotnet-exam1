using dotnet_exam1.Src.Data;
using dotnet_exam1.Src.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_exam1.Src.Repositories
{
    public class GenderRepository(DataContext dataContext) : IGenderRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<bool> ExistsGender(string gender)
        {
            return await _dataContext.Genders.AnyAsync(x => x.Name == gender);
        }
    }
}
