using MediatR;
using SPS.Core.Models.Order;
using SPS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SPS.Service.Orders.Commands.UpdateOrder
{
    public class UpdateOrderRequest: IRequest<OrderModel>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Recipient { get; set; }
        public string ShipAddress { get; set; }
        public string PhoneRecipient { get; set; }
        public decimal OrderTotal { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string SessionId { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
