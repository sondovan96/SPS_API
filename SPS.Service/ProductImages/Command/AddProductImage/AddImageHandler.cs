using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Exceptions;
using SPS.Core.Helper.Photos;
using SPS.Core.Models.Photos;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.ProductImages.Command.AddProductImage
{
    public class AddImageHandler : IRequestHandler<AddImageRequest, ProductImageModel>
    {
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IProductRepo _productRepo;
        private readonly IProductImageRepo _productImageRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddImageHandler(IPhotoAccessor photoAccessor, IProductRepo productRepo, IProductImageRepo productImageRepo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _photoAccessor = photoAccessor;
            _productRepo = productRepo;
            _productImageRepo = productImageRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductImageModel> Handle(AddImageRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.InitQuery().Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == request.ProductId);
            if (product == null)
            {
                throw new ResourceNotFoundException(nameof(request.ProductId), request.ProductId);
            }
            var photoUploadResult = await _photoAccessor.AddPhoto(request.File);
            var photo = new ProductImageModel
            {
                Url = photoUploadResult.Url,
                Id = photoUploadResult.PublicId,
            };

            if (!product.ProductImages.Any(x => x.IsMain))
            {
                photo.IsMain = true;
            }
            product.ProductImages.Add(_mapper.Map<ProductImage>(photo));
            await _unitOfWork.SaveChangesAsync();

            return photo;
        }

    }
}
