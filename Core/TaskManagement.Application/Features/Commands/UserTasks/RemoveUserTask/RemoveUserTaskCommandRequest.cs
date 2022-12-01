using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Commands.UserTasks.RemoveUserTask
{
    public class RemoveUserTaskCommandRequest :IRequest<RemoveUserTaskCommandResponse>
    {
        public string Id { get; set; }
    }
}
