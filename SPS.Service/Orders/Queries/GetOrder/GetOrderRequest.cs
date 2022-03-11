using MediatR;
using SPS.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Orders.Queries.GetOrder
{
    public class GetOrderRequest :IRequest<OrderModel>
    {
        public Guid Id { get; set; }
    }
}
