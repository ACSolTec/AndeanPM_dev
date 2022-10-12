using Andeanpm.Client.Components.Public;
using Andeanpm.Server.Data;
using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Andeanpm.Server.Services.InvestorsService
{
    public class InvestorsService : IInvestorsService
    {
        private readonly AndeampDBContext context;
        public InvestorsService(AndeampDBContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResponse<InvestorReport>> Create(InvestorReport investorReport)
        {
            context.InvestorReports.Add(investorReport);
            await context.SaveChangesAsync();

            return new ServiceResponse<InvestorReport> { Data = investorReport };
        }

        public async Task<ServiceResponse<bool>> Delete(int id)
        {
            var db = await context.InvestorReports.FindAsync(id);
            if (db == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Member not found."
                };
            }

            context.InvestorReports.Remove(db);
            await context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<InvestorReport>> Get(int id)
        {
            var response = new ServiceResponse<InvestorReport>();
            try
            {
                response.Data = await context.InvestorReports.FindAsync(id);
                response.Success = true;
                response.Message = "Get Data Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"{ex.Message} - {ex.InnerException}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<InvestorReport>>> Get()
        {
            var response = new ServiceResponse<List<InvestorReport>>();
            try
            {
                var people = await context.InvestorReports.ToListAsync();
                response.Data = people;
                response.Success = true;
                response.Message = "Get Data Success";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"{ex.Message} - {ex.InnerException}";
            }
            return response;
        }

        public async Task<PagedList<InvestorReport>> Get(PaginationParameters paginationParameters, string module)
        {
            var result = await context.InvestorReports.Where(x => x.Module.Equals(module)).OrderByDescending(x => x.Id).ToListAsync();
            return PagedList<InvestorReport>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<ServiceResponse<InvestorReport>> Update(InvestorReport investorReport)
        {
            context.InvestorReports.Update(investorReport);
            await context.SaveChangesAsync();
            return new ServiceResponse<InvestorReport> { Data = investorReport };
        }
    }
}
