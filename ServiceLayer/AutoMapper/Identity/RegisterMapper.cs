using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;

namespace ServiceLayer.AutoMapper.Identity
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper() 
        {
            CreateMap<AppUser, RegisterVM>().ReverseMap();
        }
    }
}
