using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Exceptions;
using SPS.Core.Models.Photos;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.ProductImages.Command.UpdateMainImage
{
    public class UpdateMainImageHandler : IRequestHandler<UpdateMainImageRequest, ProductImageModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepo _productRepo;
        private readonly IProductImageRepo _productImageRepo;
        private readonly IMapper _mapper;

        public UpdateMainImageHandler(IUnitOfWork unitOfWork, IProductRepo productRepo, IProductImageRepo productImageRepo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepo = productRepo;
            _productImageRepo = productImageRepo;
            _mapper = mapper;
        }

        public async Task<ProductImageModel> Handle(UpdateMainImageRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.InitQuery()
                .Include(x => x.ProductImages)
                .FirstOrDefaultAsync(x=>x.Id == request.ProductId);

            if (product == null)
            {
                throw new ResourceNotFoundException(nameof(request.ProductId), request.ProductId);
            }

            var photo = product.ProductImages.FirstOrDefault(x => x.Id == request.Id);
            if(photo == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }
            photo.IsMain = request.IsMain;

            _productImageRepo.Update(photo);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductImageModel>(photo);
        }
    }
}
