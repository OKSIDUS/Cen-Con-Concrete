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
        Task<bool> CreateJobType(JobType jobType);
        Task<bool> DeleteJobType(int id);
        Task<JobType> GetById(int id);
        Task<bool> UpdateJobType(JobType jobType);
    }
}
