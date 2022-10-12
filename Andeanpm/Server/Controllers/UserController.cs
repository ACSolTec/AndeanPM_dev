using Andeanpm.Server.Services.UserService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<User>>> Create(UserForm user)
        {
            var result = await userService.Create(new User
            {
                Email = user.Email,
                Role = user.Role,
            }, user.Password);

            return Ok(result);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> Get()
        {
            var result = await userService.Get();
            return Ok(result);
        }

        [HttpGet("pagination"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPeople([FromQuery] PaginationParameters paginationParameters)
        {
            var result = await userService.Get(paginationParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<User>>> GetMemeber(int id)
        {
            var result = await userService.Get(id);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {

            var result = await userService.Delete(id);

            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<User>>> Update(UserForm user)
        {
            var result = await userService.Update(new User
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
            }, user.Password);

            return Ok(result);
        }
    }
}
