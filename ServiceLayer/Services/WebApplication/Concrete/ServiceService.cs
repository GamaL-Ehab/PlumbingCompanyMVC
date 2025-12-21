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
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Service> _repository;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Service>();
        }



        public async Task<List<ServiceListVM>> GetAllAsync()
        {
            var serviceVM = await _repository.GetAllAsync().ProjectTo<ServiceListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return serviceVM;
        }

        public async Task<ServiceUpdateVM> GetById(int id)
        {
            var service = await _repository.Where(x => x.Id == id).ProjectTo<ServiceUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return service;
        }

        public async Task AddAsync(ServiceAddVM request)
        {
            var service = _mapper.Map<Service>(request);

            await _repository.AddAsync(service);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(ServiceUpdateVM request)
        {
            var service = _mapper.Map<Service>(request);
            _repository.Update(service);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _repository.GetByIdAsync(id);

            _repository.Delete(service);
            await _unitOfWork.CommitAsync();
        }
    }
}
