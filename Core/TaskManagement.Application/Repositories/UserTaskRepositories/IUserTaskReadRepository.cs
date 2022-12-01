using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Entities.Common;

namespace TaskManagement.Application.Repositories.UserTaskRepositories
{
    public interface IUserTaskReadRepository : IReadRepository<UserTask>
    {
    }
}
