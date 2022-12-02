using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask;
using TaskManagement.Application.Features.Commands.UserTasks.RemoveUserTask;
using TaskManagement.Application.Features.Commands.UserTasks.UpdateUserTask;
using TaskManagement.Application.Features.Queries.UserTaks.GetByIdUserTasks;
using TaskManagement.Application.Features.Queries.UserTasks.GetAllUserTasks;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    [Route("api/[controller]")]
    public class UserTaskController : Controller
    {
        readonly IMediator _mediator;

        public UserTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllUserTasksQueryRequest getAllUserTasksQueryRequest)
        {
            GetAllUserTasksQueryResponse response = await _mediator.Send(getAllUserTasksQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdUserTaskQueryRequest getByIdUserTaskQueryRequest)
        {
            GetByIdUserTaskQueryResponse response = await _mediator.Send(getByIdUserTaskQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserTaskCommandRequest createUserTaskCommandRequest)
        {
            CreateUserTaskCommandResponse response = await _mediator.Send(createUserTaskCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserTaskCommandRequest updateUserTaskCommandRequest)
        {
            UpdateUserTaskCommandResponse response = await _mediator.Send(updateUserTaskCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveUserTaskCommandRequest removeUserTaskCommandRequest)
        {
            RemoveUserTaskCommandResponse response = await _mediator.Send(removeUserTaskCommandRequest);
            return Ok();
        }
    }
}
