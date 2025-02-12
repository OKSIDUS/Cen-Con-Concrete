namespace Cen_Con.BAL.Interfaces
{
    public interface IJwtTokenService
    {
        public Task<string> GenerateToken(string username);
    }
}
