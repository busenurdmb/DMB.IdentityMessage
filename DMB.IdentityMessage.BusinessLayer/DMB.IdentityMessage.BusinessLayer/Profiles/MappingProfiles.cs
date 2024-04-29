using AutoMapper;
using DMB.IdentityMessage.BusinessLayer.Dto;
using DMB.IdentityMessage.BusinessLayer.Validation.Register;
using DMB.IdentityMessage.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.BusinessLayer.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, RegisterViewDto>().ReverseMap();
            CreateMap<AppUser, RegisterViewDto>().ReverseMap();

         CreateMap<Mail, ListMailDto>()
        .ForMember(dest => dest.ReceiverEmail, opt => opt.MapFrom(src => src.Receiver.Email)).ForMember(dest => dest.SenderEmail, opt => opt.MapFrom(src => src.Sender.Email))
        .ReverseMap();





        }
    }
}
