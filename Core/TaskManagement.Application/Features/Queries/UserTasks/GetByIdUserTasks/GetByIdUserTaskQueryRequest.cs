using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Queries.UserTaks.GetByIdUserTasks
{
    public class GetByIdUserTaskQueryRequest : IRequest<GetByIdUserTaskQueryResponse>
    {
        public string Id { get; set; }

    }
}
