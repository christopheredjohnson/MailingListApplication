using MailingListApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MailingListApplication.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services) =>
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("MailingListApplication")); // this could use many providers.
    }
}
