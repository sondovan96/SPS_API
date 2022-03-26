using AutoMapper;
using MediatR;
using SPS.Core.Helper;
using SPS.Core.Models.Product;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Products.Commands.AddProduct
{
    class AddProductHandler : IRequestHandler<AddProductRequest, ProductModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IProductRepo _productRepo;

        public AddProductHandler(IMapper mapper, IUnitOfWork unitOfWork, IProductRepo productRepo)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
            _productRepo = productRepo;
        }

        public async Task<ProductModel> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<AddProductRequest, Product>(request);
            product.CreatedDate = DateTime.UtcNow;
            product.ModifiedDate = DateTime.UtcNow;
            product.MetaTitle = SeoHelper.ToSeoUrl(request.ProductName);

            await _productRepo.AddAsync(product);

            await _unitofwork.SaveChangesAsync();

            return _mapper.Map<AddProductRequest, ProductModel>(request);
        }
    }
}
