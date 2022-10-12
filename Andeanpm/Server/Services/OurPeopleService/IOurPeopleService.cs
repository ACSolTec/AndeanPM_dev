using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.OurPeopleService
{
    public interface IOurPeopleService
    {
        Task<ServiceResponse<Person>> Create(Person member);
        Task<ServiceResponse<bool>> Delete(int id);
        Task<ServiceResponse<Person>> GetMember(int id);
        Task<ServiceResponse<List<Person>>> GetPeople();
        Task<PagedList<Person>> GetPeople(PaginationParameters paginationParameters, string team);
        Task<ServiceResponse<Person>> Update(Person member);
    }
}
