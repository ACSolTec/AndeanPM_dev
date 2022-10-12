using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.InvestorsService
{
	public interface IInvestorsService
	{
        Task<bool> Create(InvestorReport investorReport);
        Task Delete(int id);
        Task<InvestorReport> Get(int id);
        Task<List<InvestorReport>> Get();
        Task<PagingResponse<InvestorReport>> Get(PaginationParameters paginationParameters, string module);
        Task<bool> Update(InvestorReport investorReport);
    }
}
