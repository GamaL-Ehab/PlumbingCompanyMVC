using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListVM>> GetAllAsync();
        Task<CategoryUpdateVM> GetById(int id);
        Task AddAsync(CategoryAddVM request);
        Task UpdateAsync(CategoryUpdateVM request);
        Task DeleteAsync(int id);
    }
}
