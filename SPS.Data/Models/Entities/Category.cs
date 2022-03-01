using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class Category: IAuditEntity, IEntityBase
    {
        public Guid Id { get; set; }
        public string Title { set; get; }
        public string MetaTitle { set; get; }
        public Guid CreatorId { set; get; }
        public virtual Account Creator { set; get; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
