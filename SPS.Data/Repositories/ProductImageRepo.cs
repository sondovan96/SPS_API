using SPS.Data.Models;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Repositories
{
    public class ProductImageRepo:Repository<ProductImage>,IProductImageRepo
    {
        public ProductImageRepo(ApplicationDbContext context):base(context)
        {

        }
    }
}
