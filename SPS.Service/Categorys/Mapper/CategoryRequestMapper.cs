using AutoMapper;
using SPS.Core.Models.Category;
using SPS.Data.Models.Entities;
using SPS.Service.Categorys.Commands.AddCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Mapper
{
    public class CategoryRequestMapper: Profile
    {
        public CategoryRequestMapper()
        {
            CreateMap<Category, AddCategoryRequest>().ReverseMap();
            CreateMap<CategoryModel, AddCategoryRequest>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
        }
    }
}
