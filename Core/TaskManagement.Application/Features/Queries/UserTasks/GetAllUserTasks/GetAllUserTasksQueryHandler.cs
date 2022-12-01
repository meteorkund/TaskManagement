using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;

namespace TaskManagement.Application.Features.Queries.UserTasks.GetAllUserTasks
{
    public class GetAllUserTasksQueryHandler : IRequestHandler<GetAllUserTasksQueryRequest, GetAllUserTasksQueryResponse>
    {
        readonly IUserTaskReadRepository _userTaskReadRepository;
        public GetAllUserTasksQueryHandler(IUserTaskReadRepository userTaskReadRepository)
        {
            _userTaskReadRepository = userTaskReadRepository;
        }
        public async Task<GetAllUserTasksQueryResponse> Handle(GetAllUserTasksQueryRequest request, CancellationToken cancellationToken)
        {
            var userTasks = _userTaskReadRepository.GetAll(false).Select(t => new
            {
                t.Id,
                t.Description,
                t.CreatedDate,
                t.UpdatedDate
            }).ToList();

            return new()
            {
                UserTasks = userTasks
            };
        }
    }
}
