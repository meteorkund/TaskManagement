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

namespace TaskManagement.Application.Features.Queries.UserTasks.GetWeeklyUserTasks
{
    public class GetWeeklyUserTasksQueryHandler : IRequestHandler<GetWeeklyUserTasksQueryRequest, GetWeeklyUserTasksQueryResponse>
    {
        readonly IUserTaskReadRepository _userTaskReadRepository;

        public GetWeeklyUserTasksQueryHandler(IUserTaskReadRepository userTaskReadRepository)
        {
            _userTaskReadRepository = userTaskReadRepository;
        }

        public async Task<GetWeeklyUserTasksQueryResponse> Handle(GetWeeklyUserTasksQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<UserTask, bool>> filter = t => t.Days == 7;

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
