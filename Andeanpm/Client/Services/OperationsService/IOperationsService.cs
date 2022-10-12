using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.OperationsService
{
	public interface IOperationsService
	{
        Task<Operation> Get(int id);
        Task<List<Operation>> Get(string operation);
        Task<List<Operation>> Get();
        Task<PagingResponse<Operation>> Get(PaginationParameters paginationParameters, string Module);
    }
}
