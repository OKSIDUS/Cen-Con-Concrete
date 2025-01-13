using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;

namespace Cen_Con.DAL.Repositories
{
    public class TypesRepository : ITypesRepository
    {
        private readonly CenConDbContext _dbContext;

        public TypesRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Types?> GetById(int id)
        {
            try
            {
                var type = await _dbContext.Types.FindAsync(id);
                Console.WriteLine("Types Repos: " + type);
                return type;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
