using MediatR;
using Microsoft.AspNetCore.Mvc;
using SPS.Service.Accounts.JWTGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.Queries.EmailConfirm
{
    public class EmailConfirmRequest :IRequest<JWTGenerationRequest>
    {
        [FromQuery]
        public string Email { get; set; }
        [FromQuery]
        public string Token { get; set; }
    }
}
