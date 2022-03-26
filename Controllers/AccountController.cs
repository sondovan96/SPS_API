using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Core.Constants;
using SPS.Core.Models.Account;
using SPS.Service.Accounts.Command.RegisterAccount;
using SPS.Service.Accounts.JWTGeneration;
using SPS.Service.Accounts.Queries.EmailConfirm;
using SPS.Service.Accounts.Queries.EmailConfirmToken;
using SPS.Service.Accounts.Queries.GetInfoUser;
using SPS.Service.Accounts.Queries.Login;
using SPS.Service.Accounts.Queries.Logout;
using System;
using System.Security.Claims;
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

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequest request)
        {
            var accountRequest = await _mediator.Send(request);
            if(Constants.User.Email.RequireEmailConfirmation)
            {
                if(!accountRequest.IsConfirmedEmail)
                {
                    try
                    {
                        await _mediator.Send(new EmailConfirmTokenRequest
                        {
                            Email = accountRequest.Email,
                            RedirectUrl = request.EmailConfirmationRedirectUrl
                        });
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return Created("", await _mediator.Send(accountRequest));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var loginRequest = await _mediator.Send(request);
            if (loginRequest != null)
            {
                if (Constants.User.Email.RequireEmailConfirmation)
                {
                    if(!loginRequest.IsConfirmedEmail)
                    {
                        try
                        {
                            await _mediator.Send(new EmailConfirmTokenRequest
                            {
                                Email = loginRequest.Email,
                                RedirectUrl = request.EmailConfirmationRedirectUrl
                            });
                        }
                        catch (Exception)
                        {

                        }
                    }
                    
                }
                return Ok(await _mediator.Send(loginRequest));
            }
            return NotFound(Constants.Messages.LoginFail);
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await _mediator.Send(new LogoutRequest());
            return Ok();
        }
        [HttpPost("send-confirmation-email")]
        public async Task<IActionResult> SendEmailToConfirm([FromBody] EmailConfirmTokenRequest request) 
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPost("email-confirmation")]
        public async Task<IActionResult> ConfirmEmail([FromBody] EmailConfirmRequest request)
        {
            JWTGenerationRequest result= await _mediator.Send(request);
            return Ok(await _mediator.Send(result));
        }

        /// <summary>
        /// Get infomation of current user
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetInfoUser()
        {
            string userId = "";
            if(HttpContext.User.Identity is ClaimsIdentity identity)
            {
                userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            var request = new GetInfoUserRequest() { Id = Guid.Parse(userId) };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
