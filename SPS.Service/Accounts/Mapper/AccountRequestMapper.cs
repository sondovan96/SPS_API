using AutoMapper;
using SPS.Core.Models.Account;
using SPS.Data.Models.Entities;
using SPS.Service.Accounts.JWTGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Accounts.Mapper
{
    public class AccountRequestMapper : Profile
    {
        public AccountRequestMapper()
        {
            CreateMap<Account, AccountRequest>().ReverseMap();
            CreateMap<AccountModel, AccountRequest>().ReverseMap();
        }
    }
}
