using Andeanpm.Server.Providers;
using Andeanpm.Shared.Models;

namespace Andeanpm.Server.Services.BannerService
{
    public interface IBannerService
    {
        Task<ServiceResponse<List<Banner>>> GetBanners();
        Task<ServiceResponse<Banner>> GetBanner(string module);
        Task<ServiceResponse<Banner>> GetBanner(int module);
        Task<PagedList<Banner>> GetBanners(PaginationParameters paginationParameters);
        Task<ServiceResponse<Banner>> Update(Banner banner);

    }
}
