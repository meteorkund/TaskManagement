using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }

    }
}
