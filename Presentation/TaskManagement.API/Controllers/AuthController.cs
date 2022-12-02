using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Commands.AppUsers.LoginUser;
using TaskManagement.Application.Features.Commands.AppUsers.RefreshTokenLogin;

namespace TaskManagement.API.Controllers
{
    public class AuthController : Controller
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromForm] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }
    }
}
