using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.FormService
{
    public interface IFormService
    {
        Task<bool> Application(Application application);
        Task<bool> Contact(Contact contact);
        Task<PagingResponse<Application>> GetApplication(PaginationParameters paginationParameters);
        Task<PagingResponse<Contact>> GetContact(PaginationParameters paginationParameters);
        Task<PagingResponse<Subscriber>> GetSubscriber(PaginationParameters paginationParameters);
        Task<ServiceResponse<Subscriber>> Subscription(Subscriber subscriber);
        Task<bool> UpdateSubscription(Subscriber subscriber);

        
    }
}
