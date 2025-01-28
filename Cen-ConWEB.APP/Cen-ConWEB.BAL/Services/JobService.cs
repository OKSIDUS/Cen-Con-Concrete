using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.DAL.Entity;
using Cen_ConWEB.DAL.Interfaces;

namespace Cen_ConWEB.BAL.Services
{
    public class JobService : IJobService
    {
        private readonly IJobApiClient _jobApiClient;
        public JobService(IJobApiClient jobApiClient)
        {
            _jobApiClient = jobApiClient;
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _jobApiClient.GetAllJobsAsync();
        }

        public async Task<Job> GetById(int id)
        {
            return await _jobApiClient.GetById(id);
        }
    }
}
