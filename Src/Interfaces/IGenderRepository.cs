namespace dotnet_exam1.Src.Interfaces
{
    public interface IGenderRepository
    {
        Task<bool> ExistsGender(string gender);
    }
}
