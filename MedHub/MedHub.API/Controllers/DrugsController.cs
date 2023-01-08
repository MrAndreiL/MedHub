using MedHub.Application.Commands.DrugCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DrugsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DrugsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<DrugDto>> Create([FromBody] CreateDrugCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{drugId:Guid}")]
        public async Task<ActionResult<DrugDto>> GetById(Guid drugId)
        {
            var result = await mediator.Send(new GetDrugByIdQuery(drugId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DrugDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllDrugsQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{drugId:Guid}")]
        public async Task<ActionResult<DrugDto>> Update([FromBody] CreateDrugCommand command, Guid drugId)
        {
            var result = await mediator.Send(new UpdateDrugCommand(command, drugId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{drugId:Guid}")]
        public async Task<ActionResult<DrugDto>> Delete(Guid drugId)
        {
            var result = await mediator.Send(new DeleteDrugCommand(drugId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
