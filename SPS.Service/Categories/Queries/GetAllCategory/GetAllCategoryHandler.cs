using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Helper;
using SPS.Core.Models.Category;
using SPS.Core.Models.Result;
using SPS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, PageListResult<CategoryModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IPageList _pageList;
        public GetAllCategoryHandler(IMapper mapper, ICategoryRepo categoryRepo, IPageList pageList)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _pageList = pageList;
        }
        public async Task<PageListResult<CategoryModel>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var categoryModels = _categoryRepo.InitQuery()
                .Include(x => x.ParentCategory);
            var cates = _mapper.ProjectTo<CategoryModel>(categoryModels);
            var result = await _pageList.GetPaginationAsync(cates, request.PageIndex, request.PageSize);
            return result;
        }
    }
}
