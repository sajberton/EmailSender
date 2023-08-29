using EmailSender.Models.Mappers;

namespace EmailSender.Extensions
{
    public static class AutoMaperExtension
    {
        public static void AddMaperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EmailSettingsProfile),
                                   typeof(TemplateProfile),
                                   typeof(ClientProfile));
        }
    }
}
