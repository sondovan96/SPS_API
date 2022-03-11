using AutoMapper;
using MediatR;
using SPS.Core.Exceptions;
using SPS.Core.Models.Order;
using SPS.Data.Repositories;
using SPS.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Orders.Commands.UpdateStrpePayment
{
    public class UpdateStripePaymentHandler : IRequestHandler<UpdateStripePaymentRequest, OrderModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderRepo _oderRepo;

        public UpdateStripePaymentHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderRepo oderRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _oderRepo = oderRepo;
        }

        public async Task<OrderModel> Handle(UpdateStripePaymentRequest request, CancellationToken cancellationToken)
        {
            var order = await _oderRepo.FindAsync(request.Id);

            if (order == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id),request.Id);
            }

            order.SessionId = request.SessionId;
            order.PaymentStatus = request.PaymentIntentId;

            _oderRepo.Update(order);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<OrderModel>(order);
        }
    }
}
