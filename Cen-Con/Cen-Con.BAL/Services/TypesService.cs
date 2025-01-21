using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories.Interfaces;
using Serilog;

namespace Cen_Con.BAL.Services
{
    public class TypesService : ITypesService
    {
        private readonly ITypesRepository _typesRepository;

        public TypesService(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        public async Task<TypesDto?> GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _typesRepository.GetById(id);

                    if (result is not null)
                    {
                        Log.Information($"Result has name - {result.Name} and was created {result.Date}");
                        return new TypesDto
                        {
                            Name = result.Name,
                            Date = result.Date,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching the record with ID: {Id}", id);
            }
            return null;
        }
    }
}
