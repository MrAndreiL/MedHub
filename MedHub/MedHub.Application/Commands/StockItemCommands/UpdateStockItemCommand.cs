using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.StockItemCommands
{
    public class UpdateStockItemCommand : IRequest<Response<StockItemDto>>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public UpdateStockItemCommand(CreateStockItemCommand command, Guid stockItemId)
        {
            Id = stockItemId;
            Quantity = command.Quantity;
        }
    }
}
