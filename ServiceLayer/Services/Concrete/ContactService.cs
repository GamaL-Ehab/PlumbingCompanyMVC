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
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ContactUs> _repository;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<ContactUs>();
        }



        public async Task<List<ContactListVM>> GetAllAsync()
        {
            var contactUsVM = await _repository.GetAllAsync().ProjectTo<ContactListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return contactUsVM;
        }

        public async Task<ContactUpdateVM> GetById(int id)
        {
            var contact = await _repository.Where(x => x.Id == id).ProjectTo<ContactUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return contact;
        }

        public async Task AddAsync(ContactAddVM request)
        {
            var contact = _mapper.Map<ContactUs>(request);

            await _repository.AddAsync(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(ContactUpdateVM request)
        {
            var contact = _mapper.Map<ContactUs>(request);
            _repository.Update(contact);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);

            _repository.Delete(contact);
            await _unitOfWork.CommitAsync();
        }
    }
}
