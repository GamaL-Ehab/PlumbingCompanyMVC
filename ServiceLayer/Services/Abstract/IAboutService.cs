using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<AboutListVM>> GetAllAsync();
        Task<AboutUpdateVM> GetById(int id);
        Task AddAsync(AboutAddVM request);
        Task UpdateAsync(AboutUpdateVM request);
        Task DeleteAsync(int id);
    }
}
