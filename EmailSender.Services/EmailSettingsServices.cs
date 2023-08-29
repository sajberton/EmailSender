using AutoMapper;
using EmailSender.Data;
using EmailSender.Models;
using EmailSender.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Services
{
    public class EmailSettingsServices : IEmailSettingsService
    {
        private readonly EmailSenderContext _context;
        private readonly IMapper _mapper;
        public EmailSettingsServices(EmailSenderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmailSettingsModel> GetSettingsByClientIdAsync(int clientId)
        {
            try
            {
                var client = await _context.EmailSettings.Where(x => x.ClientId == clientId).FirstOrDefaultAsync();
                if (client == null)
                    return null;

                return _mapper.Map<EmailSettingsModel>(client);
            }
            catch (Exception ex)
            {
                //Logger
                throw;
            }
        }
    }
}
