using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Team> _repository;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Team>();
        }



        public async Task<List<TeamListVM>> GetAllAsync()
        {
            var teamVM = await _repository.GetAllAsync().ProjectTo<TeamListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return teamVM;
        }

        public async Task<TeamUpdateVM> GetById(int id)
        {
            var team = await _repository.Where(x => x.Id == id).ProjectTo<TeamUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return team;
        }

        public async Task AddAsync(TeamAddVM request)
        {
            var team = _mapper.Map<Team>(request);

            await _repository.AddAsync(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(TeamUpdateVM request)
        {
            var team = _mapper.Map<Team>(request);
            _repository.Update(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _repository.GetByIdAsync(id);

            _repository.Delete(team);
            await _unitOfWork.CommitAsync();
        }
    }
}
