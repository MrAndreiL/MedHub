using MedHub.Application.Commands.MedicalRecordCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.MedicalRecordQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMediator mediator;

        public MedicalRecordsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<MedicalRecordDto>> Create([FromBody] CreateMedicalRecordCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{medicalRecordId:Guid}")]
        public async Task<ActionResult<MedicalRecordDto>> GetById(Guid medicalRecordId)
        {
            var result = await mediator.Send(new GetMedicalRecordByIdQuery(medicalRecordId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicalRecordDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllMedicalRecordsQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{medicalRecordId:Guid}")]
        public async Task<ActionResult<MedicalRecordDto>> Update([FromBody] CreateMedicalRecordCommand command, Guid medicalRecordId)
        {
            var result = await mediator.Send(new UpdateMedicalRecordCommand(command, medicalRecordId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{medicalRecordId:Guid}")]
        public async Task<ActionResult<MedicalRecordDto>> Delete(Guid medicalRecordId)
        {
            var result = await mediator.Send(new DeleteMedicalRecordCommand(medicalRecordId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
