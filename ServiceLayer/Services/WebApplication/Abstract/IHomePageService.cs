using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IHomePageService
    {
        Task<List<HomePageListVM>> GetAllAsync();
        Task<HomePageUpdateVM> GetById(int id);
        Task AddAsync(HomePageAddVM request);
        Task UpdateAsync(HomePageUpdateVM request);
        Task DeleteAsync(int id);
    }
}
