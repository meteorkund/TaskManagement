using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;

namespace TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask
{
    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommandRequest, CreateUserTaskCommandResponse>
    {
        readonly IUserTaskWriteRepository _userTaskWriteRepository;

        public CreateUserTaskCommandHandler(IUserTaskWriteRepository userTaskWriteRepository)
        {
            _userTaskWriteRepository = userTaskWriteRepository;
        }

        public async Task<CreateUserTaskCommandResponse> Handle(CreateUserTaskCommandRequest request, CancellationToken cancellationToken)
        {

            await _userTaskWriteRepository.AddAsync(new()
            {
                Description = request.Description,
            });
            await _userTaskWriteRepository.SaveAsync();
            return new();
        }
    }
}

