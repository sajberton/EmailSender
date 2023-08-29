using AutoMapper;
using EmailSender.Data;
using EmailSender.Models;
using EmailSender.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly EmailSenderContext _context;
        private readonly IMapper _mapper;

        public TemplateService(EmailSenderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TemplateModel> GetTemplateByIdAsync(int templateId)
        {
            try
            {
                var template = await _context.Templates.Where(x => x.Id == templateId).FirstOrDefaultAsync();
                if (template == null)
                    return null;

                return _mapper.Map<TemplateModel>(template);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
    }
}
