using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Serilog;

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
                if (type == null)
                {
                    Log.Warning($"Type with ID {id} not found in DB");
                    return null;
                }

                Log.Information($"Type: {type.Id} with name {type.Name}");
                return type;
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message} An error occurred while retrieving type with ID {id}");
                return null;
            }
        }
    }
}
