using SPS.Data.Models;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Repositories
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
