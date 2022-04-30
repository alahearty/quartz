using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quartz.Application.Reservoirs.CommandInteractors;
using Quartz.Application.Reservoirs.QueryInteractors;
using System.Threading.Tasks;

namespace quartz.api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservoirsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservoirsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reservoirsRequest = new GetAllReservoirListRequest();
            var reservoirs = await _mediator.Send(reservoirsRequest);
            

            return Ok(reservoirs);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 0)
            {
                return BadRequest("invalid id");
            }

            var reservoirByIdRequest = new GetReservoirByIdRequest { Id = id };
            var reservoir = await _mediator.Send(reservoirByIdRequest);
            return Ok(reservoir);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReservoirRequest createReservoirRequest)
        {
            var result = await _mediator.Send(createReservoirRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateReservoirRequest updateReservoirRequest)
        {
            var result = await _mediator.Send(updateReservoirRequest);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("invalid id");
            }

            var deleteReservoirRequest = new DeleteReservoirRequest { Id = id };
            var result = await _mediator.Send(deleteReservoirRequest);

            return Ok(result);
        }
    }
}
