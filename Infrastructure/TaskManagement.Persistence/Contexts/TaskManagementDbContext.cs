using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Entities.Common;
using TaskManagement.Domain.Entities.Identity;

namespace TaskManagement.Persistence.Contexts
{
    public class TaskManagementDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public TaskManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserTask> UserTasks { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
                

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
