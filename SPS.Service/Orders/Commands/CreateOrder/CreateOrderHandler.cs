using AutoMapper;
using MediatR;
using SPS.Core.Models.Order;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, OrderModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepo _orderRepo;

        public CreateOrderHandler(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepo = orderRepo;
        }

        public async Task<OrderModel> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<CreateOrderRequest, Order>(request);
            order.OrderStatus = Data.Models.Enums.OrderStatus.Pending.ToString();
            await _orderRepo.AddAsync(order);

            var result = await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<OrderModel>(order);
        }
    }
}
