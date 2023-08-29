using EmailSender.Data.Entities;
using EmailSender.Models;
using EmailSender.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmailSender.Services
{
    public class QueueService : IQueueService
    {
        private readonly ISendEmailService _sendEmailService;
        public QueueService(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public async Task<bool> QueueSendEmailJobAsync(int clientId, int templateId, string toEmail)
        {
            try
            {
                return await EnqueueEmailForSending(clientId, templateId, toEmail);
            }
            catch (Exception ex)
            {
                //Log Exception 
                throw;
            }
        }

        public async Task<bool> QueueSendEmailJobXmlFileAsync(IFormFile xmlFile)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Clients));
                TextReader textReader = new StreamReader(xmlFile.OpenReadStream());

                Clients clients;
                clients = (Clients)deserializer.Deserialize(textReader);
                textReader.Close();
                if (clients != null)
                {
                    foreach (var client in clients?.ClientList)
                    {
                        var clientId = Int32.Parse(client.ID);
                        var templateId = Int32.Parse(client.Template.Id);

                        await EnqueueEmailForSending(clientId, templateId, "");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //Log exception 
                throw;
            }

        }

        private async Task<bool> EnqueueEmailForSending(int clientId, int templateId, string toEmail)
        {
            var jobId = BackgroundJob.Enqueue(() => _sendEmailService.SendEmailAsync(clientId, templateId, toEmail));
            if (jobId != null)
                return true;
            else
                return false;
        }
    }
}
