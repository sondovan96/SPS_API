using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Models.Category;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Categorys.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, CategoryModel>
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo, IMapper mapper)
        {
            _unitOfwork = unitOfWork;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<CategoryModel> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            //check category exists
            var category = await _categoryRepo.InitQuery().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if(category == null)
            {
                throw new Exception($"Not Found CategoryId {request.Id}");
                
            }
            category.Title = request.Title;
            category.ParentId = request.ParentId;
            category.MetaTitle = request.MetaTitle;
            category.IsDeleted = request.IsDeleted;

            _categoryRepo.Update(category);
            await _unitOfwork.SaveChangesAsync();
            return _mapper.Map<CategoryModel>(category);
        }
    }
}
