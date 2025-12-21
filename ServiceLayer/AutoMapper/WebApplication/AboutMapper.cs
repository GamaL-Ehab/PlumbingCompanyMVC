using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.AutoMapper.WebApplication
{
    public class AboutMapper : Profile
    {
        public AboutMapper()
        {
            CreateMap<AboutUs, AboutListVM>().ReverseMap();
            CreateMap<AboutUs, AboutAddVM>().ReverseMap();
            CreateMap<AboutUs, AboutUpdateVM>().ReverseMap();
        }
    }
}
