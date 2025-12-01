using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.Abstract
{
    public interface IServiceService
    {
        Task<List<ServiceListVM>> GetAllAsync();
        Task<ServiceUpdateVM> GetById(int id);
        Task AddAsync(ServiceAddVM request);
        Task UpdateAsync(ServiceUpdateVM request);
        Task DeleteAsync(int id);
    }
}
