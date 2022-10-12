using Andeanpm.Server.Data;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Andeanpm.Server.Services.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly AndeampDBContext context;

        public StatisticsService(AndeampDBContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<Statistic>> GetStatistic(int statisticId)
        {
            var response = new ServiceResponse<Statistic>();
            try
            {
                response.Data = await context.Statistics.FindAsync(statisticId);
                response.Success = true;
                response.Message = "Get Data Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"{ex.Message} - {ex.InnerException}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<Statistic>>> GetStatistics()
        {
            var response = new ServiceResponse<List<Statistic>>();
            try
            {
                var statistics = await context.Statistics.ToListAsync();
                response.Data = statistics;
                response.Success = true;
                response.Message = "Get Data Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"{ex.Message} - {ex.InnerException}";
            }
            return response;
        }

        public async Task<ServiceResponse<Statistic>> Update(Statistic statistic)
        {
            context.Statistics.Update(statistic);
            await context.SaveChangesAsync();
            return new ServiceResponse<Statistic> { Data = statistic };
        }
    }
}
