using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels;

namespace ServiceLayer.AutoMapper.WebApplication
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceListVM>().ReverseMap();
            CreateMap<Service, ServiceAddVM>().ReverseMap();
            CreateMap<Service, ServiceUpdateVM>().ReverseMap();
        }
    }
}
