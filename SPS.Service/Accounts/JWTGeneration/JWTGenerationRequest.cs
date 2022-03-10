using MediatR;
using SPS.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.JWTGeneration
{
    public class JWTGenerationRequest:IRequest<AccountModel>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsConfirmedEmail { get; set; }
        public IList<string> Roles { get; set; }
    }
}
