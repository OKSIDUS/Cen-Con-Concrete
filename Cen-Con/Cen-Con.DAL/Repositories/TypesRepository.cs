using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.INF;

namespace Cen_Con.DAL.Repositories
{
    public class TypesRepository : ITypesRepository
    {
        private readonly CenConDbContext _dbContext;
        private readonly IConsoleDebug _consoleDebug;
        
        public TypesRepository(CenConDbContext dbContext, IConsoleDebug consoleDebug)
        {
            _dbContext = dbContext;
            _consoleDebug = consoleDebug;
        }

        public async Task<Types?> GetById(int id)
        {
            try
            {
                var type = await _dbContext.Types.FindAsync(id);

                _consoleDebug.SendMessage($"Types Repository : Id: {type.Id}, Name: {type.Name}, Date: {type.Date}");


                return type;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
