using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<SocialMedia> _repository;

        public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<SocialMedia>();
        }



        public async Task<List<SocialMediaListVM>> GetAllAsync()
        {
            var socialMediaVM = await _repository.GetAllAsync().ProjectTo<SocialMediaListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return socialMediaVM;
        }

        public async Task<SocialMediaUpdateVM> GetById(int id)
        {
            var socialMedia = await _repository.Where(x => x.Id == id).ProjectTo<SocialMediaUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return socialMedia;
        }

        public async Task AddAsync(SocialMediaAddVM request)
        {
            var socialMedia = _mapper.Map<SocialMedia>(request);

            await _repository.AddAsync(socialMedia);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(SocialMediaUpdateVM request)
        {
            var socialMedia = _mapper.Map<SocialMedia>(request);
            _repository.Update(socialMedia);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var socialMedia = await _repository.GetByIdAsync(id);

            _repository.Delete(socialMedia);
            await _unitOfWork.CommitAsync();
        }
    }
}
