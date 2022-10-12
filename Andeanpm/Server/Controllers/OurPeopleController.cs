using Andeanpm.Client.Components.Public;
using Andeanpm.Server.Services.OurPeopleService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurPeopleController : ControllerBase
    {
        private readonly IOurPeopleService ourPeopleService;

        private readonly IWebHostEnvironment webHostEnvironment;

        public OurPeopleController(IOurPeopleService ourPeopleService, IWebHostEnvironment webHostEnvironment)
        {
            this.ourPeopleService = ourPeopleService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Person>>> Create(Person member)
        {
            var result = await ourPeopleService.Create(member);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Person>>>> GetPeople()
        {
            var result = await ourPeopleService.GetPeople();
            return Ok(result);
        }

        [HttpGet("pagination/{team}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPeople([FromQuery] PaginationParameters paginationParameters, string team)
        {
            var result = await ourPeopleService.GetPeople(paginationParameters, team);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Person>>> GetMemeber(int id)
        {
            var result = await ourPeopleService.GetMember(id);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {

            var member = await ourPeopleService.GetMember(id);

            string oldUploadedImageFileName = member.Data.PathImage.Split('/').Last();

            if (System.IO.File.Exists($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\our-people\\{oldUploadedImageFileName}"))
            {
                System.IO.File.Delete($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\our-people\\{oldUploadedImageFileName}");
            }

            var result = await ourPeopleService.Delete(id);

            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Person>>> Update(Person member)
        {

            var resp = await ourPeopleService.GetMember(member.Id);

            string oldUploadedImageFileName = resp.Data.PathImage.Split('/').Last();

            System.IO.File.Delete($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\our-people\\{oldUploadedImageFileName}");

            var result = await ourPeopleService.Update(member);
            return Ok(result);
        }

    }
}
