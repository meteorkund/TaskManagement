using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask
{
    public class CreateUserTaskCommandRequest : IRequest<CreateUserTaskCommandResponse>
    {
        public string Description { get; set; }
    }
}
