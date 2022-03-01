using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SPS.Core.Models.Account;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Accounts.Queries.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, AccountModel>
    {
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;
        public LoginHandler(UserManager<Account> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<AccountModel> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName)
                ?? await _userManager.FindByEmailAsync(request.UserName);

            var userModel = _mapper.Map<Account, AccountModel>(user);

            return await Task.FromResult(userModel);
        }
        
    }
}
