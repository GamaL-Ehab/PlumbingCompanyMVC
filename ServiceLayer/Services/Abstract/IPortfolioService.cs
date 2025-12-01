using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.Abstract
{
    public interface IPortfolioService
    {
        Task<List<PortfolioListVM>> GetAllAsync();
        Task<PortfolioUpdateVM> GetById(int id);
        Task AddAsync(PortfolioAddVM request);
        Task UpdateAsync(PortfolioUpdateVM request);
        Task DeleteAsync(int id);
    }
}
