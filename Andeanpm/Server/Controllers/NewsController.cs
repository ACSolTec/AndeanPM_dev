using Andeanpm.Server.Services.NewsService;
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
    public class NewsController : ControllerBase
    {
        private readonly INewsService newsService;

        private readonly IWebHostEnvironment webHostEnvironment;

        public NewsController(INewsService newsService, IWebHostEnvironment webHostEnvironment)
        {
            this.newsService = newsService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<News>>> Create(NewDTO news)
        {
            string pkNews = GetNumber();

            news.PDFURL = await CreatePDF(news.PDF.NewImageBase64Content, pkNews);

            var result = await newsService.Create(new News
                { 
                    PKNews = pkNews,
                    Title = news.Title,
                    Subtitle = news.Subtitle,
                    Content = news.Content, 
                    PDFURL = news.PDFURL
                });
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var result = await newsService.Delete(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<News>>>> GetNews()
        {
            var result = await newsService.GetNews();
            return Ok(result);
        }

        [HttpGet("pagination"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBanners([FromQuery] PaginationParameters paginationParameters)
        {
            var result = await newsService.GetNews(paginationParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("{newId}")]
        public async Task<ActionResult<ServiceResponse<News>>> GetNews(string newId)
        {
            var result = await newsService.GetNewsId(newId);
            return Ok(result);
        }

        [HttpGet("byId/{newId}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<News>>> GetNews(int newId)
        {
            var result = await newsService.GetNewsId(newId);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<News>>> Update(NewDTO news)
        {
            news.PDFURL = await CreatePDF(news.PDF.NewImageBase64Content, news.PKNews);

            var result = await newsService.Update(new News
            {
                Id = news.Id,
                PKNews = news.PKNews,
                Title = news.Title,
                Subtitle = news.Subtitle,
                Content = news.Content,
                PDFURL = news.PDFURL,
                DateNews = news.DateNews,
                Year = news.Year
            });
            return Ok(result);
        }

        private async Task<string> CreatePDF(string content, string name)
        {
            string clientPath = $"{webHostEnvironment.ContentRootPath}wwwroot\\assets\\news\\pdfs\\{name}.pdf";

            FileStream fileStream = System.IO.File.Create(clientPath);
            byte[] bytes = Convert.FromBase64String(content);

            await fileStream.WriteAsync(bytes, 0, bytes.Length);
            fileStream.Close();

            return  $"assets/news/pdfs/{name}.pdf";
        }

        private string GetNumber()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D6");
        }
    }
}
