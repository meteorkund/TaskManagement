using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Queries.UserTasks.GetDailyUserTasks
{
    public class GetDailyUserTasksQueryHandler : IRequestHandler<GetDailyUserTasksQueryRequest, GetDailyUserTasksQueryResponse>
    {
        readonly IUserTaskReadRepository _userTaskReadRepository;

        public GetDailyUserTasksQueryHandler(IUserTaskReadRepository userTaskReadRepository)
        {
            _userTaskReadRepository = userTaskReadRepository;
        }

        public async Task<GetDailyUserTasksQueryResponse> Handle(GetDailyUserTasksQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<UserTask, bool>> filter = t => t.Days == 1;

            var userTasks = await _userTaskReadRepository.GetWhere(filter).Select(t => new
            {
                t.Id,
                t.Description,
                t.CreatedDate,
                t.UpdatedDate
            }).ToListAsync();

            return new()
            {
                UserTasks = userTasks
            };
        }
    }
}
