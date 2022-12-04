using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Weekly
{
    public class CreateUserTaskWeeklyCommandRequest :IRequest<CreateUserTaskWeeklyCommandResponse>
    {
        public string Description { get; set; }
    }
}
