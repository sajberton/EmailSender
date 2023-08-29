using AutoMapper;
using EmailSender.Data;
using EmailSender.Data.Entities;
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
    public class ClientServices : IClientServices
    {
        private readonly EmailSenderContext _context;
        private readonly IMapper _mapper;

        public ClientServices(EmailSenderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateClientAsync(CreateClientModel model)
        {
            try
            {
                var client = _mapper.Map<Client>(model);
                _context.Clients.Add(client);
               return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }

        public async Task<ClientModel> GetClientByIdAsync(int id)
        {
            try
            {
                var client = await _context.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (client == null)
                    return null;

                return _mapper.Map<ClientModel>(client);
            }
            catch (Exception ex)
            {
                //Logger
                throw;
            }
        }
    }
}
