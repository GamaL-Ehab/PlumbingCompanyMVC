using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;

namespace ServiceLayer.AutoMapper.Identity
{
    public class LoginMapper : Profile
    {
        public LoginMapper() 
        {
            CreateMap<AppUser, LoginVM>().ReverseMap();
        }
    }
}
