using MedHub.Application.Commands.StockItemCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.StockItemQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StockItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StockItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<StockItemDto>> Create([FromBody] CreateStockItemCommand command)
        {
            var result = await mediator.Send(command);

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Created(nameof(GetAll), result.Entity);
            }
        }

        [HttpGet("{stockItemId:Guid}")]
        public async Task<ActionResult<StockItemDto>> GetById(Guid stockItemId)
        {
            var result = await mediator.Send(new GetStockItemByIdQuery(stockItemId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<StockItemDto>>> GetAll()
        {
            var result = await mediator.Send(new GetAllStockItemsQuery());

            switch (result.Status)
            {
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpPatch("{stockItemId:Guid}")]
        public async Task<ActionResult<StockItemDto>> Update([FromBody] CreateStockItemCommand command, Guid stockItemId)
        {
            var result = await mediator.Send(new UpdateStockItemCommand(command, stockItemId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }

        [HttpDelete("{stockItemId:Guid}")]
        public async Task<ActionResult<StockItemDto>> Delete(Guid stockItemId)
        {
            var result = await mediator.Send(new DeleteStockItemCommand(stockItemId));

            switch (result.Status)
            {
                case OperationState.NotFound: return NotFound();
                case OperationState.MappingError: return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                default: return Ok(result.Entity);
            }
        }
    }
}
