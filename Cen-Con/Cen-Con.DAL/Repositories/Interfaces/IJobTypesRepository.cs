using Cen_Con.DAL.DataContext.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cen_Con.DAL.Repositories.Interfaces
{
    public interface IJobTypesRepository
    {
        Task<List<JobType>> GetAllJobTypes();
        Task<JobType> GetById(int id);
    }
}
