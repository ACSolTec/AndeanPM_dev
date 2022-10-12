using Andeanpm.Server.Services.StatisticsService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Statistic>>>> GetStatistics()
        {
            var result = await statisticsService.GetStatistics();
            return Ok(result);
        }

        [HttpGet("getbyid/{statisticId}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Statistic>>> GetBanner(int statisticId)
        {
            var result = await statisticsService.GetStatistic(statisticId);
            return Ok(result);
        }

        [HttpPost("update"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Statistic>>> UpdateBanner(Statistic banner)
        {
            ServiceResponse<Statistic> response = new ServiceResponse<Statistic>();

            try
            {

                response = await statisticsService.Update(banner);

                return Ok(response);

            }
            catch (Exception e)
            {

                response.Success = false;
                response.Message = $"{e.Message} - {e.InnerException}";

                return Ok(response);
            }
        }
    }
}
