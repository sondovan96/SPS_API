using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.Queries.EmailConfirmToken
{
    public class EmailConfirmTokenRequest :IRequest
    {
        public string Email { get; set; }
        public string RedirectUrl { get; set; }
    }
}
