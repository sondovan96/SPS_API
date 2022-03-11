using SPS.Data.Models;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Repositories
{
    public class OrderRepo:Repository<Order>,IOrderRepo
    {
        public OrderRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
