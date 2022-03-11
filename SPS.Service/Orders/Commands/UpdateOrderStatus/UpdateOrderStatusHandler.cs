using AutoMapper;
using MediatR;
using SPS.Core.Exceptions;
using SPS.Core.Models.Order;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusRequest, OrderModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepo _orderRepo;

        public UpdateOrderStatusHandler(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepo = orderRepo;
        }

        public async Task<OrderModel> Handle(UpdateOrderStatusRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.FindAsync(request.Id);
            if (order == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }
            order.PaymentStatus = request.PaymentStatus;

            _orderRepo.Update(order);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderModel>(order);
        }
    }
}
