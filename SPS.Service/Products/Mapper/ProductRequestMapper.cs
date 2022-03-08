using AutoMapper;
using SPS.Core.Models.Product;
using SPS.Data.Models.Entities;
using SPS.Service.Products.Commands.AddProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Products.Mapper
{
    public class ProductRequestMapper : Profile
    {
        public ProductRequestMapper()
        {
            CreateMap<Product, AddProductRequest>().ReverseMap();

            CreateMap<ProductModel, AddProductRequest>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
        }
    }
}
