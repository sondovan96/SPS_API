using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Models.Account
{
    public class AccountModel
    {
        public Guid Id { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public bool IsConfirmedEmail { set; get; }
        public IList<string> Roles { get; set; }
        public Token Token { set; get; }
        public ICollection<Data.Models.Entities.FavoriteProduct> FavoriteProduct { get; set; }
    }

    public class Token
    {
        public string TokenType { set; get; }
        public string AccessToken { set; get; }
    }
}
