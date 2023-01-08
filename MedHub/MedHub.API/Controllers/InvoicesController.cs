using MedHub.Application.Commands.InvoiceCommands;
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
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator mediator;

        public InvoicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> Create([FromBody] CreateInvoiceCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{invoiceId:Guid}")]
        public async Task<ActionResult<InvoiceDto>> GetById(Guid invoiceId)
        {
            var result = await mediator.Send(new GetInvoiceByIdQuery(invoiceId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllInvoicesQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{invoiceId:Guid}")]
        public async Task<ActionResult<InvoiceDto>> Update([FromBody] CreateInvoiceCommand command, Guid invoiceId)
        {
            var result = await mediator.Send(new UpdateInvoiceCommand(command, invoiceId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{invoiceId:Guid}")]
        public async Task<ActionResult<InvoiceDto>> Delete(Guid invoiceId)
        {
            var result = await mediator.Send(new DeleteInvoiceCommand(invoiceId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
