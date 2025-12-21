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
    public class HomePageService : IHomePageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<HomePage> _repository;

        public HomePageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<HomePage>();
        }



        public async Task<List<HomePageListVM>> GetAllAsync()
        {
            var homePageVM = await _repository.GetAllAsync().ProjectTo<HomePageListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return homePageVM;
        }

        public async Task<HomePageUpdateVM> GetById(int id)
        {
            var homePage = await _repository.Where(x => x.Id == id).ProjectTo<HomePageUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return homePage;
        }

        public async Task AddAsync(HomePageAddVM request)
        {
            var homePage = _mapper.Map<HomePage>(request);

            await _repository.AddAsync(homePage);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(HomePageUpdateVM request)
        {
            var homePage = _mapper.Map<HomePage>(request);
            _repository.Update(homePage);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var homePage = await _repository.GetByIdAsync(id);

            _repository.Delete(homePage);
            await _unitOfWork.CommitAsync();
        }
    }
}
