using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaListVM>> GetAllAsync();
        Task<SocialMediaUpdateVM> GetById(int id);
        Task AddAsync(SocialMediaAddVM request);
        Task UpdateAsync(SocialMediaUpdateVM request);
        Task DeleteAsync(int id);
    }
}
