using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.OurPeopleService
{
	public interface IOurPeopleService
	{
        Task<bool> Create(Person member);
        Task Delete(int id);
        Task<Person> GetMember(int id);
        Task<List<Person>> GetPeople();
        Task<PagingResponse<Person>> GetPeople(PaginationParameters paginationParameters, string team);
        Task<bool> Update(Person member);
    }
}
