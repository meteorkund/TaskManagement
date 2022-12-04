﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Queries.UserTasks.GetDailyUserTasks
{
    public class GetDailyUserTasksQueryRequest :IRequest<GetDailyUserTasksQueryResponse>
    {
    }
}
