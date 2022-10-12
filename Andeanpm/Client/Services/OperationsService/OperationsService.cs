using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text.Json;

namespace Andeanpm.Client.Services.OperationsService
{
	public class OperationsService : IOperationsService
	{
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public OperationsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<Operation> Get(int id)
		{
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<Operation>>($"api/operation/{id}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<List<Operation>> Get(string operation)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<Operation>>>($"api/operation/byoperation/{operation}");
            Console.WriteLine(result.Data);
            return result.Data;
        }

        public async Task<List<Operation>> Get()
		{
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<Operation>>>("api/operation");

            return result.Data;
        }

		public async Task<PagingResponse<Operation>> Get(PaginationParameters paginationParameters, string team)
		{
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString($"api/operation/pagination/{team}", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Operation>
            {
                Items = JsonSerializer.Deserialize<List<Operation>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }
	}
}
