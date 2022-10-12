using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.UserService
{
	public interface IUserService
	{
        Task<ServiceResponse<User>> Create(User user, string password);
        Task<ServiceResponse<bool>> Delete(int id);
        Task<ServiceResponse<User>> Get(int id);
        Task<ServiceResponse<List<User>>> Get();
        Task<PagedList<User>> Get(PaginationParameters paginationParameters);
        Task<ServiceResponse<User>> Update(User user, string password);
    }
}
