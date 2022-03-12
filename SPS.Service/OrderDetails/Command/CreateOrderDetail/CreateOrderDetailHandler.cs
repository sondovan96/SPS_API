using AutoMapper;
using MediatR;
using SPS.Core.Models.OrderDetail;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.OrderDetails.Command.CreateOrderDetail
{
    public class CreateOrderDetailHandler : IRequestHandler<CreateOrderDetailRequest, OrderDetailModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepo _orderDetailRepo;

        public CreateOrderDetailHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderDetailRepo orderDetailRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderDetailRepo = orderDetailRepo;
        }

        public async Task<OrderDetailModel> Handle(CreateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = _mapper.Map<OrderDetail>(request);

            await _orderDetailRepo.AddAsync(orderDetail);
            return _mapper.Map<OrderDetailModel>(orderDetail);
        }
    }
}
