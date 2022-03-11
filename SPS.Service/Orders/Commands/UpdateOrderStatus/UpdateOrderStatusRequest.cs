using MediatR;
using SPS.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SPS.Service.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusRequest:IRequest<OrderModel>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string PaymentStatus { get; set; }
    }
}
