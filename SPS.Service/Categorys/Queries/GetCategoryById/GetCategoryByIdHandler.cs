using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Models.Category;
using SPS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Categorys.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, CategoryModel>
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public GetCategoryByIdHandler(ICategoryRepo categoryRepo,IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }
        public async Task<CategoryModel> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var cate = _categoryRepo.InitQuery().Include(x=>x.ParentCategory).Where(x=>x.Id == request.Id).FirstOrDefault();
            return await Task.FromResult(_mapper.Map<CategoryModel>(cate));
        }
    }
}
