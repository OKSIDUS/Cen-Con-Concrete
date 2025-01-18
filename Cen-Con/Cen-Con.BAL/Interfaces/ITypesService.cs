using Cen_Con.BAL.Dtos.Types;

namespace Cen_Con.BAL.Interfaces
{
    public interface ITypesService
    {
        Task<TypesDto?> GetById(int id);
    }
}
