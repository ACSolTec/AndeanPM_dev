using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.UserService
{
	public interface IUserService
	{
        Task<bool> Create(UserForm user);
        Task Delete(int id);
        Task<User> Get(int id);
        Task<List<User>> Get();
        Task<PagingResponse<User>> Get(PaginationParameters paginationParameters);
        Task<bool> Update(UserForm user);

    }
}
