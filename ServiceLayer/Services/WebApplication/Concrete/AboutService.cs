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
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<AboutUs> _repository;

        public AboutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<AboutUs>();
        }



        public async Task<List<AboutListVM>> GetAllAsync()
        {
            var aboutUsVM = await _repository.GetAllAsync().ProjectTo<AboutListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return aboutUsVM;
        }

        public async Task<AboutUpdateVM> GetById(int id)
        {
            var about = await _repository.Where(x => x.Id == id).ProjectTo<AboutUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return about;
        }

        public async Task AddAsync(AboutAddVM request)
        {
            var about = _mapper.Map<AboutUs>(request);

            await _repository.AddAsync(about);
            await _unitOfWork.CommitAsync();    
        }

        public async Task UpdateAsync(AboutUpdateVM request)
        {
            var about = _mapper.Map<AboutUs>(request);
            _repository.Update(about);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id) 
        {
            var about = await _repository.GetByIdAsync(id);

            _repository.Delete(about);
            await _unitOfWork.CommitAsync();
        }

    }
}
