using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Helper;
using SPS.Core.Models.Product;
using SPS.Core.Models.Result;
using SPS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Products.Queries.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, PageListResult<ProductModel>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        private readonly IPageList _pageList;

        public GetAllProductHandler(IMapper mapper, IProductRepo productRepo, IPageList pageList)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _pageList = pageList;
        }

        public async Task<PageListResult<ProductModel>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var productModel = _productRepo.InitQuery()
                .Include(x=>x.Category)
                    .ThenInclude(x=>x.ParentId)
                .Include(x=>x.ProductImages);
            var productList = _mapper.ProjectTo<ProductModel>(productModel);
            var result = await _pageList.GetPaginationAsync(productList, request.PageIndex, request.PageSize);
            return result;
        }
    }
}
