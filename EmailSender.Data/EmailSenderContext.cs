using EmailSender.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Data
{
    public class EmailSenderContext : DbContext
    {
        public EmailSenderContext(DbContextOptions<EmailSenderContext> options) : base(options)
        {
                
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<EmailSettings> EmailSettings { get; set; }
        public DbSet<Template> Templates { get; set; }
    }
}