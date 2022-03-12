using MediatR;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepo _productRepo;

        public DeleteProductHandler(IUnitOfWork unitOfWork, IProductRepo productRepo)
        {
            _unitOfWork = unitOfWork;
            _productRepo = productRepo;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.FindAsync(request.Id);
            if (product != null)
            {
                _productRepo.RemoveById(request.Id);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
