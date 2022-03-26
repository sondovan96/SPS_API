using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Service.Orders.Commands.CreateOrder;
using SPS.Service.Orders.Commands.UpdateOrderStatus;
using SPS.Service.Orders.Commands.UpdateStrpePayment;
using SPS.Service.Orders.Queries.GetOrder;
using System;
using System.Threading.Tasks;

namespace SPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] GetOrderRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{Id}/status")]
        public async Task<IActionResult> UpdateStatusOrder([FromBody] UpdateOrderStatusRequest request,[FromRoute] Guid Id)
        {
            request.Id = Id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{Id}/stripe")]
        public async Task<IActionResult> UpdateStripePayment([FromBody] UpdateStripePaymentRequest request, [FromRoute] Guid Id)
        {
            request.Id = Id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }


    }
}
