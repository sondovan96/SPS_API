using MediatR;
using SPS.Core.Models.OrderDetail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SPS.Service.OrderDetails.Command.UpdateOrderDetail
{
    public class UpdateOrderDetailRequest:IRequest<OrderDetailModel>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
