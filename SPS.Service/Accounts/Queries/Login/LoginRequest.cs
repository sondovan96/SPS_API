using MediatR;
using SPS.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPS.Service.Accounts.Queries.Login
{
    public class LoginRequest : IRequest<AccountModel>
    {
        [Required]
        public string UserName { set; get; }

        [Required]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}
