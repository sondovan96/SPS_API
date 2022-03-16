using AutoMapper;
using MediatR;
using SPS.Core.Models.Category;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Categories.Commands.AddCategory
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, CategoryModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly ICategoryRepo _categoryRepo;
        public AddCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
            _categoryRepo = categoryRepo;
        }
        public async Task<CategoryModel> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<AddCategoryRequest, Category>(request);
            if (request != null)
            {
                await _categoryRepo.AddAsync(category);
                await _unitofwork.SaveChangesAsync();
            }

            return _mapper.Map<AddCategoryRequest,CategoryModel>(request);
        }
    }
}
