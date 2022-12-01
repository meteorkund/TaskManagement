using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Persistence.Contexts;
using TaskManagement.Persistence.Repositories.UserTaskRepositories;

namespace TaskManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TaskManagementDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IUserTaskReadRepository, UserTaskReadRepository>();
            services.AddScoped<IUserTaskWriteRepository, UserTaskWriteRepository>();
        }
    }
}
