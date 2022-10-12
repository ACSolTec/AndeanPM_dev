using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace Andeanpm.Client.Services.FormService
{
    public class FormService : IFormService
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public FormService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<bool> Application(Application application)
        {
            var result = await httpClient.PostAsJsonAsync("api/forms/application", application);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Application>>()).Success;
        }

        public async Task<bool> Contact(Contact contact)
        {
            var result = await httpClient.PostAsJsonAsync("api/forms/contact", contact);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Contact>>()).Success;
        }

        public async Task<ServiceResponse<Subscriber>> Subscription(Subscriber subscriber)
        {
            var result = await httpClient.PostAsJsonAsync("api/forms/subscription", subscriber);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Subscriber>>();
        }

        public async Task<bool> UpdateSubscription(Subscriber subscriber)
        {
            var result = await httpClient.PostAsJsonAsync("api/forms/updateSubscription", subscriber);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Subscriber>>()).Success;
        }

        public async Task<PagingResponse<Application>> GetApplication(PaginationParameters paginationParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString("api/forms/pagination/application", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Application>
            {
                Items = JsonSerializer.Deserialize<List<Application>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }

        public async Task<PagingResponse<Contact>> GetContact(PaginationParameters paginationParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString($"/api/forms/pagination/contact", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Contact>
            {
                Items = JsonSerializer.Deserialize<List<Contact>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }

        public async Task<PagingResponse<Subscriber>> GetSubscriber(PaginationParameters paginationParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paginationParameters.PageNumber.ToString()
            };
            var response = await httpClient.GetAsync(QueryHelpers.AddQueryString($"/api/forms/pagination/subscriber", queryStringParam));

            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Subscriber>
            {
                Items = JsonSerializer.Deserialize<List<Subscriber>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }
    }
}
