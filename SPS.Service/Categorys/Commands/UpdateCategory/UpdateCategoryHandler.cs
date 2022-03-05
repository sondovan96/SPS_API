using MediatR;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Categorys.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, bool>
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly ICategoryRepo _categoryRepo;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
        {
            _unitOfwork = unitOfWork;
            _categoryRepo = categoryRepo;
        }

        public async Task<bool> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepo.FindAsync(request.Id);
            if(category != null)
            {
                if(request.Title != null)
                {
                    category.Title = request.Title;
                }

                if(request.MetaTitle != null)
                {
                    category.MetaTitle = request.MetaTitle;
                }

                if(request.ParentId != null)
                {
                    category.ParentId = request.ParentId;
                }

                if(request.IsDeleted == true)
                {
                    category.IsDeleted = request.IsDeleted;
                }

                _categoryRepo.Update(category);
                await _unitOfwork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
