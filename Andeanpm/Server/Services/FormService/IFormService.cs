using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.FormService
{
    public interface IFormService
    {
        Task<ServiceResponse<Application>> Application(Application application);
        Task<ServiceResponse<Contact>> Contact(Contact contact);
        Task<PagedList<Application>> GetApplication(PaginationParameters paginationParameters);
        Task<PagedList<Contact>> GetContact(PaginationParameters paginationParameters);
        Task<PagedList<Subscriber>> GetSubscriber(PaginationParameters paginationParameters);
        Task<Subscriber> GetSubscriber(string email);
        Task<ServiceResponse<Subscriber>> Subscription(Subscriber subscriber);
        Task<ServiceResponse<Subscriber>> UpdateSubscriber(Subscriber subscriber);
    }
}
