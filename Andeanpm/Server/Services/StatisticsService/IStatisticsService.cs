using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.StatisticsService
{
    public interface IStatisticsService
    {
        Task<ServiceResponse<List<Statistic>>> GetStatistics();
        Task<ServiceResponse<Statistic>> GetStatistic(int statisticId);
        Task<ServiceResponse<Statistic>> Update(Statistic statistic);
    }
}
