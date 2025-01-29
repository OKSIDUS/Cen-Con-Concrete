namespace Cen_ConWEB.DAL.Repositories.Interfaces
{
    public interface IConcreteCustomerRepository
    {
        Task<string> GetConcreteCustomerById(int id);
    }
}
