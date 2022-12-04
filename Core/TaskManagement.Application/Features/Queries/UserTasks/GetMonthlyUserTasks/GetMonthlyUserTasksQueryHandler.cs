using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Queries.UserTasks.GetMonthlyUserTasks
{
    public class GetMonthlyUserTasksQueryHandler : IRequestHandler<GetMonthlyUserTasksQueryRequest, GetMonthlyUserTasksQueryResponse>
    {
        readonly IUserTaskReadRepository _userTaskReadRepository;

        public GetMonthlyUserTasksQueryHandler(IUserTaskReadRepository userTaskReadRepository)
        {
            _userTaskReadRepository = userTaskReadRepository;
        }

        public async Task<GetMonthlyUserTasksQueryResponse> Handle(GetMonthlyUserTasksQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<UserTask, bool>> filter = t => t.Days == 30;

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
