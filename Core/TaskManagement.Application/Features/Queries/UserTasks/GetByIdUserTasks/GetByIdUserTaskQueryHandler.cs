using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Queries.UserTaks.GetByIdUserTasks
{
    public class GetByIdUserTaskQueryHandler : IRequestHandler<GetByIdUserTaskQueryRequest, GetByIdUserTaskQueryResponse>
    {
        readonly IUserTaskReadRepository _userTaskReadRepository;

        public GetByIdUserTaskQueryHandler(IUserTaskReadRepository userTaskReadRepository)
        {
            _userTaskReadRepository = userTaskReadRepository;
        }

        public async Task<GetByIdUserTaskQueryResponse> Handle(GetByIdUserTaskQueryRequest request, CancellationToken cancellationToken)
        {
            UserTask userTask = await _userTaskReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                UserTask = userTask
            };
        }
    }
}
