using EmailSender.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Extensions
{
    public static class DBContextExtension
    {
        public static void AddDbContextExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmailSenderContext>
                (opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
