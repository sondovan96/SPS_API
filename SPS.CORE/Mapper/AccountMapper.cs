using AutoMapper;
using SPS.Core.Models.Account;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Mapper
{
    public class AccountMapper:Profile
    {
        public AccountMapper()
        {
            CreateMap<Account, AccountModel>().ReverseMap();
        }
    }
}
