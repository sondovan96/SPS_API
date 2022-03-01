using MediatR;
using SPS.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.JWTGeneration
{
    public class JWTGenerationRequest:IRequest<AccountModel>
    {
        public string token { get; set; }   
    }
}
