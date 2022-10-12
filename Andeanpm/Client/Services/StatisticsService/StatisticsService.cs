using Andeanpm.Shared.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;

namespace Andeanpm.Client.Services.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HttpClient httpClient;

        public StatisticsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Statistic> GetStatistic(int statisticIds)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<Statistic>>($"api/statistics/getbyid/{statisticIds}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<List<Statistic>> GetStatistics()
        {
            ServiceResponse<List<Statistic>> res = new();

            try
            {
                res = await httpClient.GetFromJsonAsync<ServiceResponse<List<Statistic>>>("/api/statistics");
            }
            catch(Exception ex)
            {
                res.Data = new();
            }
            return res.Data;
        }

        public async Task<bool> Update(Statistic statistic)
        {
            var post = await httpClient.PostAsJsonAsync("api/statistics/update", statistic);
            return (await post.Content.ReadFromJsonAsync<ServiceResponse<Statistic>>()).Success;
        }
    }
}
