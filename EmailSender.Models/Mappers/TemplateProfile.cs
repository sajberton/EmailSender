using AutoMapper;
using EmailSender.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Models.Mappers
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile() 
        {
            CreateMap<TemplateModel, Template>().ReverseMap();
        }
    }
}
