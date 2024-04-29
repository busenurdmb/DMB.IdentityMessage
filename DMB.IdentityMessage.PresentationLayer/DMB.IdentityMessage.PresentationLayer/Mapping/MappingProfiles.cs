using AutoMapper;
using DMB.IdentityMessage.BusinessLayer.Dto;
using DMB.IdentityMessage.EntityLayer.Entities;
using DMB.IdentityMessage.PresentationLayer.Models;
using DMB.IdentityMessage.PresentationLayer.Models.Mail;

namespace DMB.IdentityMessage.PresentationLayer.Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, RegisterViewDto>().ReverseMap();
            CreateMap<AppUser, RegisterViewModel>().ReverseMap();
            CreateMap<RegisterViewDto, RegisterViewModel>().ReverseMap();
            CreateMap<ListMailDto, ListMailModel>().ReverseMap();
            CreateMap<Mail, ListMailModel>().ReverseMap();
            CreateMap<PasswordChangeViewDto, PasswordChangeViewModel>().ReverseMap();




        }
    }
}
