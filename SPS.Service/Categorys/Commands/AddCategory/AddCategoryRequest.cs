using MediatR;
using SPS.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Commands.AddCategory
{
    public class AddCategoryRequest : IRequest<CategoryModel>
    {
        public string Title { set; get; }
        public string MetaTitle { set; get; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
