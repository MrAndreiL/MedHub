using MedHub.Application.Commands.ServiceCommands;
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
    public class ServicesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> Create([FromBody] CreateServiceCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{serviceId:Guid}")]
        public async Task<ActionResult<ServiceDto>> GetById(Guid serviceId)
        {
            var result = await mediator.Send(new GetServiceByIdQuery(serviceId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllServicesQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{serviceId:Guid}")]
        public async Task<ActionResult<ServiceDto>> Update([FromBody] CreateServiceCommand command, Guid serviceId)
        {
            var result = await mediator.Send(new UpdateServiceCommand(command, serviceId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{serviceId:Guid}")]
        public async Task<ActionResult<ServiceDto>> Delete(Guid serviceId)
        {
            var result = await mediator.Send(new DeleteServiceCommand(serviceId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
