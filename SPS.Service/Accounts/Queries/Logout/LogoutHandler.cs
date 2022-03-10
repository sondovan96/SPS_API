using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SPS.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Accounts.Queries.Logout
{
    public class LogoutHandler : IRequestHandler<LogoutRequest, bool>
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutHandler(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor)
        {
            _jwtOptions = jwtOptions.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c=>c.Type.Equals(ClaimTypes.NameIdentifier));
            
            if (claim != null)
            {
                return await Task.FromResult(RemoveAudience(claim));
            }
            return await Task.FromResult(false);
        }

        /// <summary>
        /// Remove an audience from valid audiences
        /// </summary>
        /// <param name="claim"></param>
        /// <returns></returns>
        private bool RemoveAudience(Claim claim)
        {
            bool result = Guid.TryParse(claim.Value, out Guid userId);
            if(result)
            {
                string audience = JwtOptions.ValidAudiences.FirstOrDefault(a => a.StartsWith(userId.ToString()));
                if(audience != null)
                {
                    JwtOptions.ValidAudiences.Remove(audience);
                    return true;
                }
            }
            return false;
        }
    }
}
