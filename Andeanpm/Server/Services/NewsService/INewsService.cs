using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.NewsService
{
    public interface INewsService
    {
        Task<ServiceResponse<News>> Create(News member);
        Task<ServiceResponse<bool>> Delete(int id);
        Task<ServiceResponse<List<News>>> GetNews();
        Task<PagedList<News>> GetNews(PaginationParameters paginationParameters);
        Task<ServiceResponse<News>> GetNewsId(string Id);
        Task<ServiceResponse<News>> GetNewsId(int Id);
        Task<ServiceResponse<News>> Update(News news);
    }
}
