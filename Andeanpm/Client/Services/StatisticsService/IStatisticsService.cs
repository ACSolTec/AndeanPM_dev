using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.StatisticsService
{
    public interface IStatisticsService
    {
        Task<List<Statistic>> GetStatistics();
        Task<Statistic> GetStatistic(int statisticIds);
        Task<bool> Update(Statistic statistic);
    }
}
