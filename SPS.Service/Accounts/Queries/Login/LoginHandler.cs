using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SPS.Core.Models.Account;
using SPS.Data.Models.Entities;
using SPS.Service.Accounts.JWTGeneration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Accounts.Queries.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, JWTGenerationRequest>
    {
        private readonly UserManager<Account> _userManager;
        public LoginHandler(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }
        public async Task<JWTGenerationRequest> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user!=null)
            {
                bool result = await _userManager.CheckPasswordAsync(user, request.Password);
                if(result)
                {
                    Task<bool> isConfirmedEmailTask = _userManager.IsEmailConfirmedAsync(user);
                    Task<IList<string>> rolesTask = _userManager.GetRolesAsync(user);

                    return new JWTGenerationRequest
                    {
                        Email = user.Email,
                        Roles = await rolesTask,
                        IsConfirmedEmail = await isConfirmedEmailTask,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Id = user.Id
                    };
                }
            }

            return null;
        }
        
    }
}
