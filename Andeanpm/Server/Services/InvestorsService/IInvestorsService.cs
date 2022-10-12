using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.InvestorsService
{
	public interface IInvestorsService
	{
        Task<ServiceResponse<InvestorReport>> Create(InvestorReport investorReport);
        Task<ServiceResponse<bool>> Delete(int id);
        Task<ServiceResponse<InvestorReport>> Get(int id);
        Task<ServiceResponse<List<InvestorReport>>> Get();
        Task<PagedList<InvestorReport>> Get(PaginationParameters paginationParameters, string module);
        Task<ServiceResponse<InvestorReport>> Update(InvestorReport investorReport);
    }
}
