using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Commands.UserTasks.UpdateUserTask
{
    public class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommandRequest, UpdateUserTaskCommandResponse>
    {
        readonly IUserTaskReadRepository _userTaskReadRepository;
        readonly IUserTaskWriteRepository _userTaskWriteRepository;

        public UpdateUserTaskCommandHandler(IUserTaskReadRepository userTaskReadRepository, IUserTaskWriteRepository userTaskWriteRepository)
        {
            _userTaskReadRepository = userTaskReadRepository;
            _userTaskWriteRepository = userTaskWriteRepository;
        }



        public async Task<UpdateUserTaskCommandResponse> Handle(UpdateUserTaskCommandRequest request, CancellationToken cancellationToken)
        {
            UserTask userTask = await _userTaskReadRepository.GetByIdAsync(request.Id);
            userTask.Description = request.Description;
            await _userTaskWriteRepository.SaveAsync();
            return new();
        }
    }
}
