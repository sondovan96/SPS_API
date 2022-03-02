using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPS.Service.Categorys.Commands.AddCategory;
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


        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] AddCategoryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
