using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.StockItemCommands
{
    public class UpdateStockItemCommand : UpdateLineItemCommand, IRequest<Response<StockItemDto>>
    {
        public UpdateStockItemCommand(CreateStockItemCommand command, Guid stockItemId)
        {
            Id = stockItemId;
            Quantity = command.Quantity;
        }
    }
}
