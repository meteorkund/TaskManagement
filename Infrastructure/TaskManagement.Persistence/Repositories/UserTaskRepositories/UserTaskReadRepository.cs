using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistence.Contexts;

namespace TaskManagement.Persistence.Repositories.UserTaskRepositories
{
    public class UserTaskReadRepository : ReadRepository<UserTask>, IUserTaskReadRepository
    {
        public UserTaskReadRepository(TaskManagementDbContext context) : base(context)
        {
        }
    }
}
