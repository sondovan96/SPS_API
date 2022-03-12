using AutoMapper;
using SPS.Core.Models.Product;
using SPS.Data.Models.Entities;
using SPS.Service.Products.Commands.AddProduct;
using SPS.Service.Products.Commands.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Service.Products.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, AddProductRequest>().ReverseMap();

            CreateMap<ProductModel, AddProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap()
                .ForMember(d=>d.Image, o=>o.MapFrom(s=>s.ProductImages.FirstOrDefault(x=>x.IsMain).Url));
        }
    }
}
