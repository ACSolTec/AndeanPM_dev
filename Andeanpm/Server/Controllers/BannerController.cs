using Andeanpm.Server.Services.BannerService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService bannerService;

        private readonly IWebHostEnvironment webHostEnvironment;

        public BannerController(IBannerService bannerService, IWebHostEnvironment webHostEnvironment)
        {
            this.bannerService = bannerService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Banner>>>> GetBanners()
        {
            var result = await bannerService.GetBanners();
            return Ok(result);
        }

        [HttpGet("pagination"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBanners([FromQuery] PaginationParameters paginationParameters)
        {
            var result = await bannerService.GetBanners(paginationParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("getbymodule/{module}")]
        public async Task<ActionResult<ServiceResponse<Banner>>> GetBanner(string module)
        {
            var result = await bannerService.GetBanner(module);
            return Ok(result);
        }

        [HttpGet("getbyid/{bannerId}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Banner>>> GetBanner(int bannerId)
        {
            var result = await bannerService.GetBanner(bannerId);
            return Ok(result);
        }

        [HttpPost("update"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Banner>>> UpdateBanner(Banner banner)
        {
            ServiceResponse<Banner> response = new ServiceResponse<Banner>();

            try
            {
                var result = await bannerService.GetBanner(banner.Id);

                string oldUploadedImageFileName = result.Data.Url.Split('/').Last();

                System.IO.File.Delete($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\banners\\{oldUploadedImageFileName}");

                result.Data = banner;

                response = await bannerService.Update(result.Data);

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
