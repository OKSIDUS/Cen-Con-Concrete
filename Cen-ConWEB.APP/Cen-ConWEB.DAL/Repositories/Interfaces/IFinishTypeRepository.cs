using Cen_ConWEB.DAL.DataContext.Entity;

namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IFinishTypeRepository
    {
        Task<List<FinishType>> GetAll();
        Task<FinishType> GetById(int id); 
    }
}
