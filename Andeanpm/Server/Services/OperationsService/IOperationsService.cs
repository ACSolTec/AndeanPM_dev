using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.OperationsService
{
	public interface IOperationsService
	{
        Task<ServiceResponse<Operation>> Get(int id);
        Task<ServiceResponse<List<Operation>>> Get(string op);
        Task<ServiceResponse<List<Operation>>> Get();
        Task<PagedList<Operation>> Get(PaginationParameters paginationParameters, string operation);
        Task<ServiceResponse<Operation>> Update(Operation operation);
    }
}
