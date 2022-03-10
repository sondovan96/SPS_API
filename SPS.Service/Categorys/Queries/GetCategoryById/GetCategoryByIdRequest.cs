using MediatR;
using SPS.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Queries.GetCategoryById
{
    public class GetCategoryByIdRequest:IRequest<CategoryModel>
    {
        public Guid Id { get; set; }
    }
}
