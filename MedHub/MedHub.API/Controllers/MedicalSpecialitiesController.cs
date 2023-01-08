using MedHub.Application.Commands.MedicalSpecialityCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.MedicalSpecialityQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MedicalSpecialitiesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MedicalSpecialitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<MedicalSpecialityDto>> Create([FromBody] CreateMedicalSpecialityCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{medicalSpecialityId:Guid}")]
        public async Task<ActionResult<MedicalSpecialityDto>> GetById(Guid medicalSpecialityId)
        {
            var result = await mediator.Send(new GetMedicalSpecialityByIdQuery(medicalSpecialityId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicalSpecialityDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllMedicalSpecialitiesQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{medicalSpecialityId:Guid}")]
        public async Task<ActionResult<MedicalSpecialityDto>> Update([FromBody] CreateMedicalSpecialityCommand command, Guid medicalSpecialityId)
        {
            var result = await mediator.Send(new UpdateMedicalSpecialityCommand(command, medicalSpecialityId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{medicalSpecialityId:Guid}")]
        public async Task<ActionResult<MedicalSpecialityDto>> Delete(Guid medicalSpecialityId)
        {
            var result = await mediator.Send(new DeleteMedicalSpecialityCommand(medicalSpecialityId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
