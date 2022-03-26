using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Helper;
using SPS.Core.Models.Product;
using SPS.Core.Models.Result;
using SPS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Products.Queries.GetNewProduct
{
    public class GetNewProductHandler : IRequestHandler<GetNewProductRequest, PageListResult<ProductModel>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        private readonly IPageList _pageList;

        public GetNewProductHandler(IMapper mapper, IProductRepo productRepo, IPageList pageList)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _pageList = pageList;
        }

        public async Task<PageListResult<ProductModel>> Handle(GetNewProductRequest request, CancellationToken cancellationToken)
        {
            var productModel = _productRepo.InitQuery()
                .OrderByDescending(x=>x.CreatedDate)
               .Include(x => x.Category)
               .Include(x => x.ProductImages);
            var productList = _mapper.ProjectTo<ProductModel>(productModel);
            var result = await _pageList.GetPaginationAsync(productList, request.PageIndex, request.PageSize);
            return result;
        }
    }
}
