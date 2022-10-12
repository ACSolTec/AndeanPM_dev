using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.BannerService
{
    public interface IBannerService
    {
        Task<List<Banner>> GetBanners();
        Task<Banner> GetBanner(string module);
        Task<Banner> GetBanner(int module);
        Task<PagingResponse<Banner>> GetBanners(PaginationParameters paginationParameters);
        Task<bool> UpdateBanner(Banner banner);
    }
}
