using AutoMapper;
using MediatR;
using SPS.Core.Exceptions;
using SPS.Core.Models.OrderDetail;
using SPS.Data.Models.Entities;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.OrderDetails.Command.UpdateOrderDetail
{
    public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailRequest, OrderDetailModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepo _orderDetailRepo;

        public UpdateOrderDetailHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderDetailRepo orderDetailRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderDetailRepo = orderDetailRepo;
        }

        public async Task<OrderDetailModel> Handle(UpdateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepo.FindAsync(request.Id);

            if (orderDetail == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }

            var orderDetailUpdate = _mapper.Map<OrderDetail>(request);

            _orderDetailRepo.Update(orderDetailUpdate);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderDetailModel>(orderDetailUpdate);
        }
    }
}
