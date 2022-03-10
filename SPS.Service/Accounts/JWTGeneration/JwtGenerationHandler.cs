using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SPS.Core.Constants;
using SPS.Core.Models.Account;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Accounts.JWTGeneration
{

    public class JwtGenerationHandler : IRequestHandler<JWTGenerationRequest, AccountModel>
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserManager<Account> _userManager;
        private readonly JwtOptions _jwtOptions;

        public JwtGenerationHandler(IOptions<JwtOptions> jwtOptions,IMapper mapper, IConfiguration configuration, UserManager<Account> userManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<AccountModel> Handle(JWTGenerationRequest request, CancellationToken cancellationToken)
        {
            string token = GenerateToken(request);
            AccountModel accountModel = _mapper.Map<AccountModel>(request);
            accountModel.Token = new Token
            {
                TokenType = Constants.HTTPClient.BearerTokenHeader,
                AccessToken = token,
            };
            return await Task.FromResult(accountModel);
        }

        private IList<Claim> GetClaims(JWTGenerationRequest request)
        {
            IList<Claim> authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,request.Id.ToString()),
                new Claim(ClaimTypes.Email,request.Email),
                new Claim(ClaimTypes.Name, request.FirstName + " "+ request.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in request.Roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            return authClaims;
        }

        private string GenerateToken(JWTGenerationRequest request)
        {
            //Remove exist audience of the user
            //If the audience is existed, then force the current logged in user to log out
            string audience = JwtOptions.ValidAudiences.FirstOrDefault(a => a.StartsWith(request.Id.ToString()));
            if (audience == null)
            {
                JwtOptions.ValidAudiences.Remove(audience);
            }

            //Add new audience to list of valid audiences
            audience = request.Id.ToString() + DateTime.UtcNow;
            JwtOptions.ValidAudiences.Add(audience);

            //Generate token
            SymmetricSecurityKey authLoginKey = new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)
                );

            JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer:_jwtOptions.Issuer,
                    audience: audience,
                    claims: GetClaims(request),
                    expires: DateTime.UtcNow.AddMinutes(120),
                    signingCredentials: new SigningCredentials(authLoginKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
