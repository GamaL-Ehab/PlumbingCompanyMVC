using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.Services.Abstract
{
    public interface ITeamService
    {
        Task<List<TeamListVM>> GetAllAsync();
        Task<TeamUpdateVM> GetById(int id);
        Task AddAsync(TeamAddVM request);
        Task UpdateAsync(TeamUpdateVM request);
        Task DeleteAsync(int id);
    }
}
