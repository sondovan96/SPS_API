using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public class Category: EntityBase, IAuditEntity
    {
        public string Title { set; get; }
        public string MetaTitle { set; get; }
        public Guid? ParentId { get; set; }
        public bool IsDeleted { set; get; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> ChildCategories { get; }
        public virtual ICollection<Product> Products { set; get; }
    }
}
