namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IFinishTypeRepository
    {
        Task<string> GetFinishTypeNameById(int id); 
    }
}
