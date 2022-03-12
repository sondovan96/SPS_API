using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Exceptions;
using SPS.Core.Helper.Photos;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.ProductImages.Command.DeleteProductImage
{
    public class DeleteImageHandler : IRequestHandler<DeleteImageRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IProductRepo _productRepo;

        public DeleteImageHandler(IUnitOfWork unitOfWork, IPhotoAccessor photoAccessor, IProductRepo productRepo)
        {
            _unitOfWork = unitOfWork;
            _photoAccessor = photoAccessor;
            _productRepo = productRepo;
        }

        public async Task<bool> Handle(DeleteImageRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.InitQuery()
                .Include(x => x.ProductImages)
                .FirstOrDefaultAsync(x => x.Id == request.ProductId);

            if (product == null)
            {
                throw new ResourceNotFoundException(nameof(request.ProductId), request.ProductId);
            }

            var photo = product.ProductImages.FirstOrDefault(x => x.Id == request.Id);

            if (photo == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }

            if (photo.IsMain)
            {
                throw new ValidationException(new ValidationFailure[1]
                 {
                    new ValidationFailure(nameof(photo.IsMain),"You cannot delete main photo of Product")
                 });
            }

            var result = await _photoAccessor.DeletePhoto(photo.Id);
            if (result == null)
            {
                throw new ValidationException(new ValidationFailure[1]
                 {
                    new ValidationFailure(result,"Problem deleting photo from Cloudinary!")
                 });
            }
            product.ProductImages.Remove(photo);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
