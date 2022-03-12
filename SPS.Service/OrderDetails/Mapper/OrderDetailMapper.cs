using AutoMapper;
using SPS.Core.Models.OrderDetail;
using SPS.Data.Models.Entities;
using SPS.Service.OrderDetails.Command.CreateOrderDetail;
using SPS.Service.OrderDetails.Command.UpdateOrderDetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.OrderDetails.Mapper
{
    public class OrderDetailMapper: Profile
    {
        public OrderDetailMapper()
        {
            CreateMap<OrderDetailModel, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailRequest, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailRequest, OrderDetail>().ReverseMap();
        }
    }
}
