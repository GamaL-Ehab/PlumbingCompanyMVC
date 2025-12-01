using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ContactVM;

namespace ServiceLayer.AutoMapper
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<ContactUs, ContactListVM>().ReverseMap();
            CreateMap<ContactUs, ContactAddVM>().ReverseMap();
            CreateMap<ContactUs, ContactUpdateVM>().ReverseMap();
        }
    }
}
