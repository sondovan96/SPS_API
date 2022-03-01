using SPS.Data.Models;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Repositories
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
