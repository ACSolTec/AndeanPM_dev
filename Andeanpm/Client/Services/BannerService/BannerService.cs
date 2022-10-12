using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace Andeanpm.Client.Services.BannerService
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public BannerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Banner> GetBanner(string module)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<Banner>>($"api/banner/getbymodule/{module}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<Banner> GetBanner(int bannerId)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<Banner>>($"api/banner/getbyid/{bannerId}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<List<Banner>> GetBanners()
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<Banner>>>("api/banner");

            return result.Data;
        }

        public async Task<PagingResponse<Banner>> GetBanners(PaginationParameters paginationParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString("api/banner/pagination", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Banner>
            {
                Items = JsonSerializer.Deserialize<List<Banner>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }

        public async Task<bool> UpdateBanner(Banner banner)
        {
            var post = await httpClient.PostAsJsonAsync("api/banner/update", banner);
            return (await post.Content.ReadFromJsonAsync<ServiceResponse<Banner>>()).Success;
        }
    }
}
