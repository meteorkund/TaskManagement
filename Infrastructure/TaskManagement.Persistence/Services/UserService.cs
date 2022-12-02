using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Services;
using TaskManagement.Application.DTOs.Users;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Features.Commands.AppUsers.CreateUser;
using TaskManagement.Domain.Entities.Identity;

namespace TaskManagement.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            if (model.Password == model.PasswordConfirm)
            {
                IdentityResult result = await _userManager.CreateAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    NameSurname = model.NameSurname,
                    UserName = model.Username,
                    Email = model.Email
                }, model.Password);

                CreateUserResponse response = new() { Succeeded = result.Succeeded };

                if (result.Succeeded)
                    response.Message = "Kullanıcı oluşturuldu";
                else
                    foreach (var error in result.Errors)
                        response.Message += $"{error.Code} - {error.Description}\n";
                return response;
            }
            else
                throw new UserCreateFailedException();
        }

        public async Task UpdateRefreshToken(AppUser appUser, string refreshToken, DateTime accessTokenDateTime, int addTokenLifeTime)
        {
            if (appUser != null)
            {
                appUser.RefreshToken = refreshToken;
                appUser.RefreshTokenEndDate = accessTokenDateTime.AddMinutes(addTokenLifeTime);
                await _userManager.UpdateAsync(appUser);
            }
            else
                throw new NotFoundUserException();
        }
    }
}
