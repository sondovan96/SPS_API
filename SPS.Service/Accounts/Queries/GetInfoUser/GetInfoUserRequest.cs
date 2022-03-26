using MediatR;
using SPS.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.Queries.GetInfoUser
{
    public class GetInfoUserRequest:IRequest<AccountDetailModel>
    {
        public Guid Id { get; set; }
    }
}
