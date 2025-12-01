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
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Portfolio> _repository;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Portfolio>();
        }



        public async Task<List<PortfolioListVM>> GetAllAsync()
        {
            var portfolioVM = await _repository.GetAllAsync().ProjectTo<PortfolioListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return portfolioVM;
        }

        public async Task<PortfolioUpdateVM> GetById(int id)
        {
            var portfolio = await _repository.Where(x => x.Id == id).ProjectTo<PortfolioUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return portfolio;
        }

        public async Task AddAsync(PortfolioAddVM request)
        {
            var portfolio = _mapper.Map<Portfolio>(request);

            await _repository.AddAsync(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(PortfolioUpdateVM request)
        {
            var portfolio = _mapper.Map<Portfolio>(request);
            _repository.Update(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var portfolio = await _repository.GetByIdAsync(id);

            _repository.Delete(portfolio);
            await _unitOfWork.CommitAsync();
        }
    }
}
