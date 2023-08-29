using EmailSender.Models;
using EmailSender.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IEmailSettingsService _emailSettingsService;
        private readonly ITemplateService _templateService;
        private readonly IClientServices _clientServices;
        public SendEmailService(IEmailSettingsService emailSettingsService, ITemplateService templateService, IClientServices clientServices)
        {
            _emailSettingsService = emailSettingsService;
            _templateService = templateService;
            _clientServices = clientServices;

        }
        public async Task SendEmailAsync(int clientId, int templateId, string toEmail)
        {
            try
            {
                var emailSettings = await _emailSettingsService.GetSettingsByClientIdAsync(clientId);
                var template = await _templateService.GetTemplateByIdAsync(templateId);

                if (emailSettings == null || template == null)
                {
                    //Log the clientId, TemplateId, toEmail;
                    return;
                };

                if (string.IsNullOrEmpty(toEmail))
                {
                    var client = await _clientServices.GetClientByIdAsync(clientId);
                    if (client == null)
                    {
                        //Log the clientId, TemplateId, toEmail;
                        return;
                    }
                    toEmail = client.Mail;
                };

                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(emailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = template.Subject;
                var builder = new BodyBuilder();

                builder.HtmlBody = template.HTML;
                //posibly add logic for variables 
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailSettings.Mail, emailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }
        }
    }
}
