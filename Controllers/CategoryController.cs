using MediatR;
using Microsoft.AspNetCore.Mvc;
using SPS.Core.Models.Category;
using SPS.Core.Models.Result;
using SPS.Service.Categories.Commands.AddCategory;
using SPS.Service.Categories.Commands.DeleteCategory;
using SPS.Service.Categories.Commands.UpdateCategory;
using SPS.Service.Categories.Queries.GetAllCategory;
using SPS.Service.Categories.Queries.GetCategoryById;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get All category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategory([FromQuery] GetAllCategoryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] AddCategoryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Delete Category by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryRequest request)
        {
            if (await _mediator.Send(request) == false)
            {
                return NotFound("Cannout found your category!");
            }
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCategory/{Id}")]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryRequest request,[FromRoute(Name ="Id")] Guid Id)
        {
            request.Id = Id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
