using MediatR;
using Microsoft.AspNetCore.Mvc;
using SPS.Core.Models.Category;
using SPS.Core.Models.Result;
using SPS.Service.Categorys.Commands.AddCategory;
using SPS.Service.Categorys.Commands.DeleteCategory;
using SPS.Service.Categorys.Queries.GetAllCategory;
using Swashbuckle.AspNetCore.Annotations;
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
    }
}
