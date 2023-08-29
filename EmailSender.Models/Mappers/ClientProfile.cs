using AutoMapper;
using EmailSender.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmailSender.Models.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientModel, Client>().ReverseMap();

            CreateMap<CreateClientModel, Client>()
                .ForMember(src => src.Name, opt => opt.MapFrom(o => o.ClientName))
                .ForMember(src => src.Mail, opt => opt.MapFrom(o => o.ClientEmail))
                .ForPath(src => src.EmailSettings.Mail, opt => opt.MapFrom(o => o.Mail))
                .ForPath(src => src.EmailSettings.DisplayName, opt => opt.MapFrom(o => o.DisplayName))
                .ForPath(src => src.EmailSettings.Password, opt => opt.MapFrom(o => o.Password))
                .ForPath(src => src.EmailSettings.Host, opt => opt.MapFrom(o => o.Host))
                .ForPath(src => src.EmailSettings.Port, opt => opt.MapFrom(o => o.Port));
        }
    }
}
