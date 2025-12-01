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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _repository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Category>();
        }



        public async Task<List<CategoryListVM>> GetAllAsync()
        {
            var categoryVM = await _repository.GetAllAsync().ProjectTo<CategoryListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return categoryVM;
        }

        public async Task<CategoryUpdateVM> GetById(int id)
        {
            var category = await _repository.Where(x => x.Id == id).ProjectTo<CategoryUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return category;
        }

        public async Task AddAsync(CategoryAddVM request)
        {
            var category = _mapper.Map<Category>(request);

            await _repository.AddAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(CategoryUpdateVM request)
        {
            var category = _mapper.Map<Category>(request);
            _repository.Update(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            _repository.Delete(category);
            await _unitOfWork.CommitAsync();
        }
    }
}
