using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime);
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
