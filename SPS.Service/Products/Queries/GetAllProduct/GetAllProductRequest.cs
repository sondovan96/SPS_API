using MediatR;
using SPS.Core.Models.Product;
using SPS.Core.Models.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Products.Queries.GetAllProduct
{
    public class GetAllProductRequest :IRequest<PageListResult<ProductModel>>
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 5;
    }
}
