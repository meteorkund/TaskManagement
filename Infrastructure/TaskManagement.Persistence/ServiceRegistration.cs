using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Abstractions.Services;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities.Identity;
using TaskManagement.Persistence.Contexts;
using TaskManagement.Persistence.Repositories.UserTaskRepositories;
using TaskManagement.Persistence.Services;

namespace TaskManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TaskManagementDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<TaskManagementDbContext>();

            services.AddScoped<IUserTaskReadRepository, UserTaskReadRepository>();
            services.AddScoped<IUserTaskWriteRepository, UserTaskWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
