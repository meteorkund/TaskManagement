using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Services;
using TaskManagement.Application.Abstractions.Tokens;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Features.Commands.AppUsers.CreateUser;
using TaskManagement.Domain.Entities.Identity;

namespace TaskManagement.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;


        public LoginUserCommandHandler(IAuthService authService )
        {
            _authService = authService;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.Username, request.Password, 5);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
