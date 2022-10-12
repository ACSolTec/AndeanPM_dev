using Andeanpm.Client.Components.Public;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Diagnostics.Metrics;
using System.Net.Http.Json;
using System.Text.Json;

namespace Andeanpm.Client.Services.InvestorsService
{
	public class InvestorsService : IInvestorsService
	{
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public InvestorsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<bool> Create(InvestorReport investorReport)
		{
            var result = await httpClient.PostAsJsonAsync("api/investor", investorReport);
            var newProduct = (await result.Content.ReadFromJsonAsync<ServiceResponse<InvestorReport>>()).Success;
            return newProduct;
        }

		public async Task Delete(int id)
		{
            var result = await httpClient.DeleteAsync($"/api/investor/{id}");
        }

		public async Task<InvestorReport> Get(int id)
		{
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<InvestorReport>>($"api/investor/{id}");
            Console.WriteLine(result.Data);
            return result.Data;
        }


		public async Task<List<InvestorReport>> Get()
		{
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<InvestorReport>>>("api/investor");

            return result.Data;
        }

		public async Task<PagingResponse<InvestorReport>> Get(PaginationParameters paginationParameters, string module)
		{
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString($"api/investor/pagination/{module}", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<InvestorReport>
            {
                Items = JsonSerializer.Deserialize<List<InvestorReport>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }

		public async Task<bool> Update(InvestorReport investorReport)
		{
            var post = await httpClient.PutAsJsonAsync("api/investor", investorReport);
            return (await post.Content.ReadFromJsonAsync<ServiceResponse<InvestorReport>>()).Success;
        }
	}
}
