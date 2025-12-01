using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;

namespace ServiceLayer.AutoMapper
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
