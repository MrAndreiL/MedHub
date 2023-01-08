using MedHub.Application.Commands.AppointmentCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.AppointmentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> Create([FromBody] CreateAppointmentCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{appointmentId:Guid}")]
        public async Task<ActionResult<AppointmentDto>> GetById(Guid appointmentId)
        {
            var result = await mediator.Send(new GetAppointmentByIdQuery(appointmentId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllAppointmentsQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{appointmentId:Guid}")]
        public async Task<ActionResult<AppointmentDto>> Update([FromBody] CreateAppointmentCommand command, Guid appointmentId)
        {
            var result = await mediator.Send(new UpdateAppointmentCommand(command, appointmentId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{appointmentId:Guid}")]
        public async Task<ActionResult<AppointmentDto>> Delete(Guid appointmentId)
        {
            var result = await mediator.Send(new DeleteAppointmentCommand(appointmentId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
