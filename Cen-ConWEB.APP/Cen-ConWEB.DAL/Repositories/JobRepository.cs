﻿using Cen_ConWEB.DAL.DataContext.Entity;
using Cen_ConWEB.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Cen_ConWEB.DAL.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly HttpClient _httpClient;

        public JobRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Job>>("api/get-jobs");
            return response ?? new List<Job>();
        }

        public async Task<Job> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Job>($"api/get-job-by-id/{id}");
            return response ?? new Job();
        }
    }
}
