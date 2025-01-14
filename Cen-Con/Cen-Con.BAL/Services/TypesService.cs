using Cen_Con.BAL.Dtos.Types;
using Cen_Con.BAL.Interfaces;
using Cen_Con.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (id > 0)
            {
                var result = await _typesRepository.GetById(id);
                Console.WriteLine("TypesService" + result);
                if (result is not null)
                {
                    return new TypesDto
                    {
                        Name = result.Name,
                        Date = result.Date,
                    };
                }
            }

            return null;
        }
    }
}
