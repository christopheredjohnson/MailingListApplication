using Microsoft.EntityFrameworkCore;
using MailingListApplication.Core.Entities;


namespace MailingListApplication.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
