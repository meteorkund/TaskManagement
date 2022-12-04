using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;

namespace TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Daily
{
    public class CreateUserTaskDailyCommandHandler : IRequestHandler<CreateUserTaskDailyCommandRequest, CreateUserTaskDailyCommandResponse>
    {
        readonly IUserTaskWriteRepository _userTaskWriteRepository;

        public CreateUserTaskDailyCommandHandler(IUserTaskWriteRepository userTaskWriteRepository)
        {
            _userTaskWriteRepository = userTaskWriteRepository;
        }

        public async Task<CreateUserTaskDailyCommandResponse> Handle(CreateUserTaskDailyCommandRequest request, CancellationToken cancellationToken)
        {

            await _userTaskWriteRepository.AddAsync(new()
            {
                Description = request.Description,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Days = 1,
                IsDone = false
            }); ;
            await _userTaskWriteRepository.SaveAsync();
            return new();
        }
    }
}

