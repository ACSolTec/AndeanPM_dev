using Andeanpm.Server.Data;
using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Andeanpm.Server.Services.FormService
{
    public class FormService : IFormService
    {
        private readonly AndeampDBContext context;

        public FormService(AndeampDBContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<Application>> Application(Application application)
        {
            context.Applications.Add(application);
            await context.SaveChangesAsync();
            return new ServiceResponse<Application> { Data = application };
        }

        public async Task<ServiceResponse<Contact>> Contact(Contact contact)
        {
            context.Contacts.Add(contact);
            await context.SaveChangesAsync();
            return new ServiceResponse<Contact> { Data = contact };
        }
        public async Task<PagedList<Application>> GetApplication(PaginationParameters paginationParameters)
        {
            var result = await context.Applications.ToListAsync();
            return PagedList<Application>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<PagedList<Contact>> GetContact(PaginationParameters paginationParameters)
        {
            var result = await context.Contacts.ToListAsync();
            return PagedList<Contact>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }
        public async Task<PagedList<Subscriber>> GetSubscriber(PaginationParameters paginationParameters)
        {
            var result = await context.Subscribers.ToListAsync();
            return PagedList<Subscriber>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public Task<Subscriber> GetSubscriber(string email)
        {
            return context.Subscribers.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<ServiceResponse<Subscriber>> Subscription(Subscriber subscriber)
        {
            context.Subscribers.Add(subscriber);
            await context.SaveChangesAsync();
            return new ServiceResponse<Subscriber> { Data = subscriber };
        }

        public async Task<ServiceResponse<Subscriber>> UpdateSubscriber(Subscriber subscriber)
        {
            context.Subscribers.Update(subscriber);
            await context.SaveChangesAsync();
            return new ServiceResponse<Subscriber> { Data = subscriber };
        }
    }
}
