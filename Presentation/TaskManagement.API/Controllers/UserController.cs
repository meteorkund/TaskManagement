using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Commands.AppUsers.CreateUser;
using TaskManagement.Application.Features.Commands.AppUsers.LoginUser;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

    }
}
