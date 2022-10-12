using Andeanpm.Server.Data;
using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Andeanpm.Server.Services.BannerService
{
    public class BannerService : IBannerService
    {
        private readonly AndeampDBContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public BannerService(AndeampDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<Banner>> GetBanner(string module)
        {
            var response = new ServiceResponse<Banner>();
            try
            {
                response.Data = await context.Banners.FirstOrDefaultAsync(x => x.Module.Equals(module));
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
        public async Task<ServiceResponse<Banner>> GetBanner(int bannerId)
        {
            var response = new ServiceResponse<Banner>();
            try
            {
                response.Data = await context.Banners.AsNoTracking().FirstOrDefaultAsync( x => x.Id == bannerId);
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

        public async Task<ServiceResponse<List<Banner>>> GetBanners()
        {
            var response = new ServiceResponse<List<Banner>>();
            try
            {
                response.Data = await context.Banners.ToListAsync();
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

        public async Task<PagedList<Banner>> GetBanners(PaginationParameters paginationParameters)
        {
            var result = await context.Banners.ToListAsync();
            return PagedList<Banner>.ToPagedList(result, paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<ServiceResponse<Banner>> Update(Banner banner)
        {
            context.Banners.Update(banner);
            await context.SaveChangesAsync();
            return new ServiceResponse<Banner> { Data = banner };
        }
    }
}
