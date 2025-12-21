using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IContactService
    {
        Task<List<ContactListVM>> GetAllAsync();
        Task<ContactUpdateVM> GetById(int id);
        Task AddAsync(ContactAddVM request);
        Task UpdateAsync(ContactUpdateVM request);
        Task DeleteAsync(int id);
    }
}
