using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Service.Products.Commands.AddProduct;
using SPS.Service.Products.Commands.DeleteProduct;
using SPS.Service.Products.Commands.UpdateProduct;
using SPS.Service.Products.Queries.GetAllProduct;
using SPS.Service.Products.Queries.GetFeaturedProduct;
using SPS.Service.Products.Queries.GetHotProduct;
using SPS.Service.Products.Queries.GetNewProduct;
using SPS.Service.Products.Queries.GetProductById;
using System;
using System.Threading.Tasks;

namespace SPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get all product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// GetNewProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetNewProduct")]
        public async Task<IActionResult> GetNewProduct([FromQuery] GetNewProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// GetHotProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetHotProduct")]
        public async Task<IActionResult> GetHotProduct([FromQuery] GetHotProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// GetFeaturedProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetFeaturedProduct")]
        public async Task<IActionResult> GetFeaturedProduct([FromQuery] GetFeaturedProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Create new Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Update product by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request, [FromRoute] Guid Id)
        {
            request.Id = Id;
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Delete Product by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductRequest request)
        {
            if(await _mediator.Send(request))
            {
                return Ok();
            }
            return NotFound("Delete Fail!");
        }
    }
}
