using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.AuthService
{
	public interface IAuthService
	{
        Task<ServiceResponse<string>> Login(UserLogin request);
        Task<bool> IsUserAuthenticated();
    }
}
