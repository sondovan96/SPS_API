using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Models.Category
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Title { set; get; }
        public string MetaTitle { set; get; }
        public Guid? ParentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
