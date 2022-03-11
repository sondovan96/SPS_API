using MediatR;
using SPS.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SPS.Service.Orders.Commands.UpdateStrpePayment
{
    public class UpdateStripePaymentRequest:IRequest<OrderModel>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string SessionId { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
