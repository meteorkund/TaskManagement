using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;

namespace TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Weekly
{
    public class CreateUserTaskWeeklyCommandHandler : IRequestHandler<CreateUserTaskWeeklyCommandRequest, CreateUserTaskWeeklyCommandResponse>
    {
        readonly IUserTaskWriteRepository _userTaskWriteRepository;

        public CreateUserTaskWeeklyCommandHandler(IUserTaskWriteRepository userTaskWriteRepository)
        {
            _userTaskWriteRepository = userTaskWriteRepository;
        }

        public async Task<CreateUserTaskWeeklyCommandResponse> Handle(CreateUserTaskWeeklyCommandRequest request, CancellationToken cancellationToken)
        {
            await _userTaskWriteRepository.AddAsync(new()
            {
                Description = request.Description,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Days = 7,
                IsDone = false

            });
            await _userTaskWriteRepository.SaveAsync();
            return new();
        }
    }
}
