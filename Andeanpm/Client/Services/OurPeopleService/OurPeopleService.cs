using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Andeanpm.Client.Services.OurPeopleService
{
    public class OurPeopleService : IOurPeopleService
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public OurPeopleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<bool> Create(Person member)
        {
            var result = await httpClient.PostAsJsonAsync("/api/ourpeople", member);
            var newProduct = (await result.Content.ReadFromJsonAsync<ServiceResponse<Person>>()).Success;
            return newProduct;
        }

        public async Task Delete(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/ourpeople/{id}");
        }

        public async Task<Person> GetMember(int id)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<Person>>($"api/ourpeople/{id}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<List<Person>> GetPeople()
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<Person>>>("api/ourpeople");

            return result.Data;
        }

        public async Task<PagingResponse<Person>> GetPeople(PaginationParameters paginationParameters, string team)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString($"api/ourpeople/pagination/{team}", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Person>
            {
                Items = JsonSerializer.Deserialize<List<Person>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }

        public async Task<bool> Update(Person member)
        {
            var post = await httpClient.PutAsJsonAsync("api/ourpeople", member);
            return (await post.Content.ReadFromJsonAsync<ServiceResponse<Person>>()).Success;
        }
    }
}
