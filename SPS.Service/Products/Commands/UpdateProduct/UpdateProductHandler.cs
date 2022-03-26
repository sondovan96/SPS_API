using AutoMapper;
using MediatR;
using SPS.Core.Exceptions;
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

namespace SPS.Service.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ProductModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepo productRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepo = productRepo;
        }

        public async Task<ProductModel> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.FindAsync(request.Id);
            if (product == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }
            product = _mapper.Map<Product>(request);
            product.MetaTitle = SeoHelper.ToSeoUrl(request.ProductName);
            product.ModifiedDate = DateTime.UtcNow;

            _productRepo.Update(product);

            return _mapper.Map<ProductModel>(product);
        }
    }
}
