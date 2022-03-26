using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPS.Service.Roles.Queries.GetRoles;
using System.Threading.Tasks;

namespace SPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles([FromQuery]GetRoleRequest request)
        {
            var listRole = await _mediator.Send(request);
            return Ok(listRole);
        }
    }
}
