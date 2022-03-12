using AutoMapper;
using SPS.Core.Models.Photos;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.ProductImages.Mapper
{
    public class ProductImageMapper:Profile
    {
        public ProductImageMapper()
        {
            CreateMap<ProductImage, ProductImageModel>().ReverseMap();
        }
    }
}
