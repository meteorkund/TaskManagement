using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Services;
using TaskManagement.Application.DTOs.Users;
using TaskManagement.Application.Exceptions;
using TaskManagement.Domain.Entities.Identity;

namespace TaskManagement.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse createUserResponse = await _userService.CreateAsync(new()
            {
                NameSurname = request.NameSurname,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });

            return new()
            {
                Message = createUserResponse.Message,
                Succeeded = createUserResponse.Succeeded
            };

        }
    }
}
