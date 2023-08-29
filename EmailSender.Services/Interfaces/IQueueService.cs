using EmailSender.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Services.Interfaces
{
    public interface IQueueService
    {
        Task<bool> QueueSendEmailJobAsync(int clientId, int templateId, string toEmail);
        Task<bool> QueueSendEmailJobXmlFileAsync(IFormFile xmlFile);
    }
}
