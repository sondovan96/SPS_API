using AutoMapper;
using SPS.Core.Models.Order;
using SPS.Data.Models.Entities;
using SPS.Service.Orders.Commands.CreateOrder;
using SPS.Service.Orders.Commands.UpdateOrder;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Orders.Mapper
{
    public class OrderMapper:Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Order, CreateOrderRequest>().ReverseMap();
            CreateMap<Order, UpdateOrderRequest>().ReverseMap();
        }
    }
}
