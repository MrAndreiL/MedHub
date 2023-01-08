using MedHub.Application.Commands.DoctorCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.DoctorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DoctorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> Create([FromBody] CreateDoctorCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{doctorId:Guid}")]
        public async Task<ActionResult<DoctorDto>> GetById(Guid doctorId)
        {
            var result = await mediator.Send(new GetDoctorByIdQuery(doctorId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllDoctorsQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{doctorId:Guid}")]
        public async Task<ActionResult<DoctorDto>> Update([FromBody] CreateDoctorCommand command, Guid doctorId)
        {
            var result = await mediator.Send(new UpdateDoctorCommand(command, doctorId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{doctorId:Guid}")]
        public async Task<ActionResult<DoctorDto>> Delete(Guid doctorId)
        {
            var result = await mediator.Send(new DeleteDoctorCommand(doctorId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
