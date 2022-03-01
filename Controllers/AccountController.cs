using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Core.Constants;
using SPS.Core.Models.Account;
using SPS.Service.Accounts.JWTGeneration;
using SPS.Service.Accounts.Queries.Login;
using System.Threading.Tasks;

namespace SPS.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _mediator.Send(loginRequest);

            
            if (user != null)
            {
                var accountRequest = _mapper.Map<AccountModel, AccountRequest>(user);

                var token = await _mediator.Send(accountRequest);
                return Ok(new { token = token });
            }

            return NotFound(Constants.Messages.LoginFail);
        }
    }
}
