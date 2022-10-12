using Andeanpm.Server.Data;
using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Andeanpm.Server.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly AndeampDBContext context;
        public NewsService(AndeampDBContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<News>> Create(News news)
        {
            context.News.Add(news);
            await context.SaveChangesAsync();

            return new ServiceResponse<News> { Data = news };
        }

        public async Task<ServiceResponse<bool>> Delete(int id)
        {
            var db = await context.News.FindAsync(id);
            if (db == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Member not found."
                };
            }

            context.News.Remove(db);
            await context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<News>>> GetNews()
        {
            var response = new ServiceResponse<List<News>>();
            try
            {
                response.Data = await context.News.ToListAsync();
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

        public async Task<PagedList<News>> GetNews(PaginationParameters paginationParameters)
        {
            var result = await context.News.OrderByDescending(x => x.DateNews).ToListAsync();
            return PagedList<News>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<ServiceResponse<News>> GetNewsId(string Id)
        {
            var response = new ServiceResponse<News>();
            try
            {
                response.Data = await context.News.FirstOrDefaultAsync(x => x.PKNews.Equals(Id));
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

        public async Task<ServiceResponse<News>> GetNewsId(int Id)
        {
            var response = new ServiceResponse<News>();
            try
            {
                response.Data = await context.News.FindAsync(Id);
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

        public async Task<ServiceResponse<News>> Update(News news)
        {
            context.News.Update(news);
            await context.SaveChangesAsync();
            return new ServiceResponse<News> { Data = news };
        }
    }
}
