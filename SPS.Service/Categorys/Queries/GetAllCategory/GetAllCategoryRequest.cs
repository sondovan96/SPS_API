using MediatR;
using SPS.Core.Models.Category;
using SPS.Core.Models.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Queries.GetAllCategory
{
    public  class GetAllCategoryRequest:IRequest<PageListResult<CategoryModel>>
    {
        public int PageIndex { get; set;} = 0;
        public int PageSize { get; set;} = 5;
    }
}
