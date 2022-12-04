using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Commands.UserTasks.UpdateUserTask
{
    public class UpdateUserTaskCommandRequest : IRequest<UpdateUserTaskCommandResponse>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
