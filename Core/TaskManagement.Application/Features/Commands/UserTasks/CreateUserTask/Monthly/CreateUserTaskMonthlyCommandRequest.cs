using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Monthly
{
    public class CreateUserTaskMonthlyCommandRequest :IRequest<CreateUserTaskMonthlyCommandResponse>
    {
        public string Description { get; set; }
    }
}
