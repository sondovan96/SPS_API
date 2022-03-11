using AutoMapper;
using MediatR;
using SPS.Core.Exceptions;
using SPS.Core.Models.Order;
using SPS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Orders.Queries.GetOrder
{
    public class GetOrderHandler : IRequestHandler<GetOrderRequest, OrderModel>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;

        public GetOrderHandler(IMapper mapper, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        public async Task<OrderModel> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.FindAsync(request.Id);

            if (order == null)
            {
                throw new ResourceNotFoundException(nameof(request.Id), request.Id);
            }

            return  _mapper.Map<OrderModel>(order);
        }
    }
}
