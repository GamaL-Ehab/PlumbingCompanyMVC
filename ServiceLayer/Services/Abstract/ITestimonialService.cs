using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.Abstract
{
    public interface ITestimonialService
    {
        Task<List<TestimonialListVM>> GetAllAsync();
        Task<TestimonialUpdateVM> GetById(int id);
        Task AddAsync(TestimonialAddVM request);
        Task UpdateAsync(TestimonialUpdateVM request);
        Task DeleteAsync(int id);
    }
}
