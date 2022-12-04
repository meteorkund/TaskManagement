using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;

namespace TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Monthly
{
    public class CreateUserTaskMonthlyCommandHandler : IRequestHandler<CreateUserTaskMonthlyCommandRequest, CreateUserTaskMonthlyCommandResponse>
    {
        readonly IUserTaskWriteRepository _userTaskWriteRepository;

        public CreateUserTaskMonthlyCommandHandler(IUserTaskWriteRepository userTaskWriteRepository)
        {
            _userTaskWriteRepository = userTaskWriteRepository;
        }

        public async Task<CreateUserTaskMonthlyCommandResponse> Handle(CreateUserTaskMonthlyCommandRequest request, CancellationToken cancellationToken)
        {
            await _userTaskWriteRepository.AddAsync(new()
            {
                Description = request.Description,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),
                Days = 30,
                IsDone = false

            });
            await _userTaskWriteRepository.SaveAsync();
            return new();
        }
    }
}
