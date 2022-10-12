using Andeanpm.Server.Services.InvestorsService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private readonly IInvestorsService investorsService;

        private readonly IWebHostEnvironment webHostEnvironment;

        public InvestorController(IInvestorsService ourPeopleService, IWebHostEnvironment webHostEnvironment)
        {
            this.investorsService = ourPeopleService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<InvestorReport>>> Create(InvestorReport investorReport)
        {
            investorReport.Url = await CreatePDF(investorReport.PDF.NewImageBase64Content, investorReport.Title, investorReport.Module);

            var result = await investorsService.Create(investorReport);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<InvestorReport>>>> GetPeople()
        {
            var result = await investorsService.Get();
            return Ok(result);
        }

        [HttpGet("pagination/{report}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPeople([FromQuery] PaginationParameters paginationParameters, string report)
        {
            var result = await investorsService.Get(paginationParameters, report);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<InvestorReport>>> GetMemeber(int id)
        {
            var result = await investorsService.Get(id);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {

            var investorReport = await investorsService.Get(id);

            string oldUploadedImageFileName = investorReport.Data.Url.Split('/').Last();

            if (System.IO.File.Exists($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\{investorReport.Data.Module}\\{oldUploadedImageFileName}"))
            {
                System.IO.File.Delete($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\{investorReport.Data.Module}\\{oldUploadedImageFileName}");
            }

            var result = await investorsService.Delete(id);

            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<InvestorReport>>> Update(InvestorReport investorReport)
        {
            if(!string.IsNullOrEmpty(investorReport.PDF.NewImageBase64Content))
                investorReport.Url = await CreatePDF(investorReport.PDF.NewImageBase64Content, investorReport.Title, investorReport.Module);

            var result = await investorsService.Update(investorReport);
            return Ok(result);
        }

        private async Task<string> CreatePDF(string content, string name, string module)
        {
            string clientPath = $"{webHostEnvironment.ContentRootPath}wwwroot\\assets\\news\\pdfs\\{name}.pdf";

            FileStream fileStream = System.IO.File.Create(clientPath);
            byte[] bytes = Convert.FromBase64String(content);

            await fileStream.WriteAsync(bytes, 0, bytes.Length);
            fileStream.Close();

            return $"assets/news/pdfs/{name}.pdf";
        }
    }
}
