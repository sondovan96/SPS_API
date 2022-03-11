using SPS.Data.Models;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Repositories
{
    public class OrderDetailRepo:Repository<OrderDetail>, IOrderDetailRepo
    {
        public OrderDetailRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
