using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
using TaskManagement.Application.Features.Commands.AppUsers.LoginUser;
using TaskManagement.Domain.Entities.Identity;

namespace TaskManagement.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }


        public async Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                throw new NotFoundUserException();
            }

            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, password, false);
            if (signInResult.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, appUser);
                await _userService.UpdateRefreshToken(appUser, token.RefreshToken, token.Expiration, 3);
                return token;
            }
            throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (appUser != null && appUser?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(5, appUser);
                _userService.UpdateRefreshToken(appUser, token.RefreshToken, token.Expiration, 5);
                return token;
            }
            else
                throw new NotFoundUserException();
        }
    }
}
