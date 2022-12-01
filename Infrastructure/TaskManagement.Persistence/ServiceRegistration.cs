using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using TaskManagement.Persistence.Contexts;


namespace TaskManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TaskManagementDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

        }
    }
}
