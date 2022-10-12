using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;
using System.Net.Http.Json;
using System.Text.Json;

namespace Andeanpm.Client.Services.NewsService
{
	public class NewsService : INewsService
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public NewsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<bool> Create(NewDTO news)
        {
            var result = await httpClient.PostAsJsonAsync("/api/news", news);
            var newProduct = (await result.Content.ReadFromJsonAsync<ServiceResponse<News>>()).Success;
            return newProduct;
        }

        public async Task Delete(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/news/{id}");
        }

        public async Task<List<News>> GetNews()
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<News>>>("api/news");

            return result.Data;
        }

        public async Task<PagingResponse<News>> GetNews(PaginationParameters paginationParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString("api/news/pagination", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<News>
            {
                Items = JsonSerializer.Deserialize<List<News>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }

        public async Task<News> GetNewsId(int Id)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<News>>($"api/news/byId/{Id}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<News> GetNewsId(string Id)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<News>>($"api/news/{Id}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<bool> Update(NewDTO news)
        {
            var post = await httpClient.PutAsJsonAsync("api/news", news);
            return (await post.Content.ReadFromJsonAsync<ServiceResponse<News>>()).Success;
        }
    }
}
