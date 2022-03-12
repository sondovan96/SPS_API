using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Exceptions;
using SPS.Core.Models.Product;
using SPS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest,ProductModel>
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductModel> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product =  await _productRepo.InitQuery()
                .Include(x => x.Category)
                .Include(x => x.ProductImages)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }

            return _mapper.Map<ProductModel>(product);
        }
    }
}
