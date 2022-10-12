using Andeanpm.Client.Components.Public;
using Andeanpm.Server.Data;
using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Andeanpm.Server.Services.OperationsService
{
	public class OperationsService : IOperationsService
    {
        private readonly AndeampDBContext context;
        public OperationsService(AndeampDBContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResponse<Operation>> Get(int id)
		{
            var response = new ServiceResponse<Operation>();
            try
            {
                response.Data = await context.Operation.FindAsync(id);
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

		public async Task<ServiceResponse<List<Operation>>> Get()
		{
            var response = new ServiceResponse<List<Operation>>();
            try
            {
                var people = await context.Operation.ToListAsync();
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

		public async Task<PagedList<Operation>> Get(PaginationParameters paginationParameters, string operation)
		{
            var result = await context.Operation.Where(x => x.Module.Equals(operation)).ToListAsync();
            return PagedList<Operation>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<ServiceResponse<List<Operation>>> Get(string op)
        {
            var response = new ServiceResponse<List<Operation>>();
            try
            {
                var people = await context.Operation.Where( x => x.Module.Equals(op)).ToListAsync();
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

        public async Task<ServiceResponse<Operation>> Update(Operation operation)
        {
            context.Operation.Update(operation);
            await context.SaveChangesAsync();
            return new ServiceResponse<Operation> { Data = operation };
        }
    }
}
