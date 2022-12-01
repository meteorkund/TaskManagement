using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;

namespace TaskManagement.Application.Features.Commands.UserTasks.RemoveUserTask
{
    public class RemoveUserTaskCommandHandler : IRequestHandler<RemoveUserTaskCommandRequest, RemoveUserTaskCommandResponse>
    {
        readonly IUserTaskWriteRepository _userTaskWriteRepository;

        public RemoveUserTaskCommandHandler(IUserTaskWriteRepository userTaskWriteRepository)
        {
            _userTaskWriteRepository = userTaskWriteRepository;
        }

        public async Task<RemoveUserTaskCommandResponse> Handle(RemoveUserTaskCommandRequest request, CancellationToken cancellationToken)
        {
            await _userTaskWriteRepository.RemoveAsync(request.Id);
            await _userTaskWriteRepository.SaveAsync();
            return new();
        }


    }
}
