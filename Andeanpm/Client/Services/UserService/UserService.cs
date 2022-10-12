using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Diagnostics.Metrics;
using System.Net.Http.Json;
using System.Text.Json;

namespace Andeanpm.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<bool> Create(UserForm user)
        {
            var result = await httpClient.PostAsJsonAsync("api/user", user);
            var newProduct = (await result.Content.ReadFromJsonAsync<ServiceResponse<User>>()).Success;
            return newProduct;
        }

        public async Task Delete(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/user/{id}");
        }

        public async Task<User> Get(int id)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<User>>($"api/user/{id}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<List<User>> Get()
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<User>>>("api/user");

            return result.Data;
        }

        public async Task<PagingResponse<User>> Get(PaginationParameters paginationParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString($"api/user/pagination/", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<User>
            {
                Items = JsonSerializer.Deserialize<List<User>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }

        public async Task<bool> Update(UserForm user)
        {
            var post = await httpClient.PutAsJsonAsync("api/user", user);
            return (await post.Content.ReadFromJsonAsync<ServiceResponse<User>>()).Success;
        }
    }
}
