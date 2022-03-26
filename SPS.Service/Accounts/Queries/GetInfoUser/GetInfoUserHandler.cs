using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SPS.Core.Exceptions;
using SPS.Core.Models.Account;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Accounts.Queries.GetInfoUser
{
    public class GetInfoUserHandler : IRequestHandler<GetInfoUserRequest, AccountDetailModel>
    {
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;

        public GetInfoUserHandler(UserManager<Account> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AccountDetailModel> Handle(GetInfoUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if(user==null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }
            return _mapper.Map<AccountDetailModel>(user);
        }
    }
}
