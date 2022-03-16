using MediatR;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, bool>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ICategoryRepo _categoryRepo;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
        {
            _unitofwork = unitOfWork;
            _categoryRepo = categoryRepo;
        }

        public async Task<bool> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepo.FindAsync(request.Id);
            if (category != null)
            {
                _categoryRepo.RemoveById(request.Id);
                await _unitofwork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
