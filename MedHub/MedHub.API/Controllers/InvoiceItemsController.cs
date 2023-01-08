using MedHub.Application.Commands.InvoiceItemCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceItemQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public InvoiceItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceItemDto>> Create([FromBody] CreateInvoiceItemCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{invoiceItemId:Guid}")]
        public async Task<ActionResult<InvoiceItemDto>> GetById(Guid invoiceItemId)
        {
            var result = await mediator.Send(new GetInvoiceItemByIdQuery(invoiceItemId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceItemDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllInvoiceItemsQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{invoiceItemId:Guid}")]
        public async Task<ActionResult<InvoiceItemDto>> Update([FromBody] CreateInvoiceItemCommand command, Guid invoiceItemId)
        {
            var result = await mediator.Send(new UpdateInvoiceItemCommand(command, invoiceItemId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{invoiceItemId:Guid}")]
        public async Task<ActionResult<InvoiceItemDto>> Delete(Guid invoiceItemId)
        {
            var result = await mediator.Send(new DeleteInvoiceItemCommand(invoiceItemId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
