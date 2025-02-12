namespace Cen_Con.BAL.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string email, string password);
    }
}
