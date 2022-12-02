using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs.Users;
using TaskManagement.Domain.Entities.Identity;

namespace TaskManagement.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);

        Task UpdateRefreshToken(AppUser appUser, string refreshToken, DateTime accessTokenDateTime, int addTokenLifeTime);
    }
}
