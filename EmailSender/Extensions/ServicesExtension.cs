using EmailSender.Services;
using EmailSender.Services.Interfaces;

namespace EmailSender.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<IEmailSettingsService, EmailSettingsServices>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IQueueService, QueueService>();
            services.AddScoped<IClientServices, ClientServices>();
        }
    }
}
