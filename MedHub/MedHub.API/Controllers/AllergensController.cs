using MedHub.Application.Commands.AllergenCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.AllergenQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AllergensController : ControllerBase
    {
        private readonly IMediator mediator;

        public AllergensController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AllergenDto>> Create([FromBody] CreateAllergenCommand command)
        {
            var result = await mediator.Send(command);
            
            switch(result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{allergenId:Guid}")]
        public async Task<ActionResult<AllergenDto>> GetById(Guid allergenId)
        {
            var result = await mediator.Send(new GetAllergenByIdQuery(allergenId));
            
            switch(result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<AllergenDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllAllergensQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{allergenId:Guid}")]
        public async Task<ActionResult<AllergenDto>> Update([FromBody] CreateAllergenCommand command, Guid allergenId)
        {
            var result = await mediator.Send(new UpdateAllergenCommand(command, allergenId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
        
        [HttpDelete("{allergenId:Guid}")]
        public async Task<ActionResult<AllergenDto>> Delete(Guid allergenId)
        {
            var result = await mediator.Send(new DeleteAllergenCommand(allergenId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
