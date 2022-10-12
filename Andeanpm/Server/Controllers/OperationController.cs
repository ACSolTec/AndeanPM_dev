using Andeanpm.Server.Services.OperationsService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationsService operationsService;

        public OperationController(IOperationsService operationsService)
        {
            this.operationsService = operationsService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Operation>>>> Get()
        {
            var result = await operationsService.Get();
            return Ok(result);
        }

        [HttpGet("pagination/{operation}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPeople([FromQuery] PaginationParameters paginationParameters, string operation)
        {
            var result = await operationsService.Get(paginationParameters, operation);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Operation>>> GetMemeber(int id)
        {
            var result = await operationsService.Get(id);
            return Ok(result);
        }

        [HttpGet("byoperation/{op}"),]
        public async Task<ActionResult<ServiceResponse<List<Operation>>>> GetOperationByOp(string op)
        {
            var result = await operationsService.Get(op);
            return Ok(result);
        }
    }
}
