using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Service.ProductImages.Command.AddProductImage;
using SPS.Service.ProductImages.Command.DeleteProductImage;
using SPS.Service.ProductImages.Command.UpdateMainImage;
using System.Threading.Tasks;

namespace SPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Add image of product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddImage([FromForm]AddImageRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateMainImage([FromForm] UpdateMainImageRequest request,[FromRoute] string Id)
        {
            request.Id = Id;
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Delete image of Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteImage([FromForm] DeleteImageRequest request, string Id)
        {   
            request.Id = Id;
            if(await _mediator.Send(request))
            {
                return Ok("Delete Image success!");
            }
            return NotFound("Delete Fail");
        }
    }
}
