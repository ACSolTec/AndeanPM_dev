using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.NewsService
{
	public interface INewsService
	{
        Task<bool> Create(NewDTO news);
        Task Delete(int id);
        Task<List<News>> GetNews();
        Task<PagingResponse<News>> GetNews(PaginationParameters paginationParameters);
        Task<News> GetNewsId(int Id);
        Task<News> GetNewsId(string Id);
        Task<bool> Update(NewDTO news);
    }
}
