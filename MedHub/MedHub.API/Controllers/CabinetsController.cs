using MedHub.Application.Commands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CabinetsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CabinetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CabinetDto>> Create([FromBody] CreateCabinetCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{cabinetId:Guid}")]
        public async Task<ActionResult<CabinetDto>> GetById(Guid cabinetId)
        {
            var result = await mediator.Send(new GetCabinetByIdQuery(cabinetId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CabinetDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllCabinetsQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPut("{cabinetId:Guid}")]
        public async Task<ActionResult<CabinetDto>> Update([FromBody] CreateCabinetCommand command, Guid cabinetId)
        {
            var result = await mediator.Send(new UpdateCabinetCommand(command, cabinetId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{cabinetId:Guid}")]
        public async Task<ActionResult<CabinetDto>> Delete(Guid cabinetId)
        {
            var result = await mediator.Send(new DeleteCabinetCommand(cabinetId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
