namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IJobTypeRepository
    {
        Task<string> GetJobTypeByIdAsync(int id);
    }
}
