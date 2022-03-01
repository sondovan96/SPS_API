using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Models.Account
{
    public class AccountModel
    {
        public Guid Id { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string FullName { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime ModifiedDate { set; get; }
        public DateTime DateOfBirth { set; get; }
        public bool Gender { set; get; }
    }
}
