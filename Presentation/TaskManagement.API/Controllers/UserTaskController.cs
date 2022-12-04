using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Daily;
using TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Monthly;
using TaskManagement.Application.Features.Commands.UserTasks.CreateUserTask.Weekly;
using TaskManagement.Application.Features.Commands.UserTasks.RemoveUserTask;
using TaskManagement.Application.Features.Commands.UserTasks.UpdateUserTask;
using TaskManagement.Application.Features.Queries.UserTaks.GetByIdUserTasks;
using TaskManagement.Application.Features.Queries.UserTasks.GetAllUserTasks;
using TaskManagement.Application.Features.Queries.UserTasks.GetDailyUserTasks;
using TaskManagement.Application.Features.Queries.UserTasks.GetMonthlyUserTasks;
using TaskManagement.Application.Features.Queries.UserTasks.GetWeeklyUserTasks;
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
        [Route("GetAllTasks")]
        public async Task<IActionResult> Get([FromQuery] GetAllUserTasksQueryRequest getAllUserTasksQueryRequest)
        {
            GetAllUserTasksQueryResponse response = await _mediator.Send(getAllUserTasksQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetDaily")]
        public async Task<IActionResult> GetDaily([FromQuery] GetDailyUserTasksQueryRequest  getDailyUserTasksQueryRequest)
        {
            GetDailyUserTasksQueryResponse response = await _mediator.Send(getDailyUserTasksQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetWeekly")]
        public async Task<IActionResult> GetWeekly([FromQuery] GetWeeklyUserTasksQueryRequest getMonthlyUserTasksQueryRequest)
        {
            GetWeeklyUserTasksQueryResponse response = await _mediator.Send(getMonthlyUserTasksQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetMonthly")]
        public async Task<IActionResult> GetMonthly([FromQuery] GetMonthlyUserTasksQueryRequest getMonthlyUserTasksQueryRequest)
        {
            GetMonthlyUserTasksQueryResponse response = await _mediator.Send(getMonthlyUserTasksQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdUserTaskQueryRequest getByIdUserTaskQueryRequest)
        {
            GetByIdUserTaskQueryResponse response = await _mediator.Send(getByIdUserTaskQueryRequest);
            return Ok(response);
        }



        [HttpPost]
        [Route("PostDaily")]
        public async Task<IActionResult> PostDaily(CreateUserTaskDailyCommandRequest createUserTaskDailyCommandRequest)
        {
            CreateUserTaskDailyCommandResponse response = await _mediator.Send(createUserTaskDailyCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("PostWeekly")]

        public async Task<IActionResult> PostWeekly(CreateUserTaskWeeklyCommandRequest createUserTaskWeeklyCommandRequest)
        {
            CreateUserTaskWeeklyCommandResponse response = await _mediator.Send(createUserTaskWeeklyCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("PostMonthly")]

        public async Task<IActionResult> PostMonthly(CreateUserTaskMonthlyCommandRequest createUserTaskMonthlyCommandRequest)
        {
            CreateUserTaskMonthlyCommandResponse response = await _mediator.Send(createUserTaskMonthlyCommandRequest);
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
