using MediatR;
using SPS.Core.Models.OrderDetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.OrderDetails.Command.CreateOrderDetail
{
    public class CreateOrderDetailRequest:IRequest<OrderDetailModel>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
