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
    public class TestimonialService : ITestimonialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Testimonial> _repository;

        public TestimonialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Testimonial>();
        }



        public async Task<List<TestimonialListVM>> GetAllAsync()
        {
            var testimonialVM = await _repository.GetAllAsync().ProjectTo<TestimonialListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return testimonialVM;
        }

        public async Task<TestimonialUpdateVM> GetById(int id)
        {
            var testimonial = await _repository.Where(x => x.Id == id).ProjectTo<TestimonialUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return testimonial;
        }

        public async Task AddAsync(TestimonialAddVM request)
        {
            var testimonial = _mapper.Map<Testimonial>(request);

            await _repository.AddAsync(testimonial);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(TestimonialUpdateVM request)
        {
            var testimonial = _mapper.Map<Testimonial>(request);
            _repository.Update(testimonial);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var testimonial = await _repository.GetByIdAsync(id);

            _repository.Delete(testimonial);
            await _unitOfWork.CommitAsync();
        }
    }
}
