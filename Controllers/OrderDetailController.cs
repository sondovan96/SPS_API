using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Service.OrderDetails.Command.CreateOrderDetail;
using SPS.Service.OrderDetails.Command.UpdateOrderDetail;
using System;
using System.Threading.Tasks;

namespace SPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Create Order Detail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody]CreateOrderDetailRequest request) 
        {

            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Update Order Detail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateOrderDetail([FromBody] UpdateOrderDetailRequest request,[FromRoute]Guid Id)
        {
            request.Id = Id;
            return Ok(await _mediator.Send(request));
        }
    }
}
