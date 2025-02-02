
using Cen_Con.DAL.DataContext.Entity;
using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.Repositories.Interfaces;
using Serilog;
using Microsoft.EntityFrameworkCore;

namespace Cen_Con.DAL.Repositories
{
    public class ConcreteSuppliersRepository : IConcreteSuppliersRepository
    {
        private readonly CenConDbContext _dbContext;
        public ConcreteSuppliersRepository(CenConDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConcreteSuppliers>> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _dbContext.ConcreteSuppliers.ToListAsync();
                if (suppliers is null)
                {
                    Log.Warning($"No concrete suppliers were found!");
                }
                return suppliers;
            }
            catch (Exception ex)
            {
                Log.Error($"The action GetAllSupplieirs() has finished with error: {ex.Message}!");
                return null;
            }
        }

        public async Task<ConcreteSuppliers?> GetById(int id)
        {
            try
            {
                var supplier = await _dbContext.ConcreteSuppliers.FindAsync(id);

                if (supplier == null)
                {
                    Log.Warning($"The concrete supplier with ID {id} wasn't found!");
                    return null;
                }

                return supplier;
            }
            catch (Exception ex)
            {
                Log.Error($"The concrete supplier get by id process has finished with error: {ex.Message}!");
                return null;
            }
        }

        public async Task<bool> CreateConcreteSupplier(ConcreteSuppliers supplier)
        {
            try
            {
                if (supplier is not null)
                {
                    await _dbContext.ConcreteSuppliers.AddAsync(supplier);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The concrete supplier wasn't created cause of missing information!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The concrete supplier create process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> DeleteConcreteSupplier(int id)
        {
            try
            {
                var supplier = await _dbContext.ConcreteSuppliers.FindAsync(id);
                if (supplier is not null)
                {
                    _dbContext.ConcreteSuppliers.Remove(supplier);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                Log.Warning($"The concrete supplier with ID {id} wasn't found!");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The concrete supplier delete process has finished with error: {ex.Message}!");
                return false;
            }
        }

        public async Task<bool> UpdateConcreteSupplier(ConcreteSuppliers supplier)
        {
            try
            {
                if (supplier is not null)
                {
                    _dbContext.ConcreteSuppliers.Update(supplier);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                Log.Warning($"The concrete supplier information wasn't update cause of missing information");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"The concrete supplier update process has finished with error: {ex.Message}!");
                return false;
            }
        }
    }
}
