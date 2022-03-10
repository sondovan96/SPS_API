using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class Account : IdentityUser<Guid>, IAuditEntity, IDeleteEntity
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string FullName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public bool Gender { set; get; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Order> Orders { set; get; }
    }
}
