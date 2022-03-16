using SPS.Data.Models;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Repositories
{
    public class FavoriteProductRepo : Repository<FavoriteProduct>, IFavoriteProductRepo
    {
        public FavoriteProductRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
