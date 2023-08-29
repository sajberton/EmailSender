using Hangfire;
using Hangfire.SqlServer;

namespace EmailSender.Extensions
{
    public static class HangfireExtension
    {
        public static void AddHangfireExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var t = configuration.GetConnectionString("HangfireConnection");

            services.AddHangfire(config=> config
           .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
           .UseSimpleAssemblyNameTypeSerializer()
           .UseRecommendedSerializerSettings()
           .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
           {
               CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
               SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
               QueuePollInterval = TimeSpan.Zero,
               UseRecommendedIsolationLevel = true,
               DisableGlobalLocks = true
           }));
            services.AddHangfireServer();
        }
    }
}
