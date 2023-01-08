using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.StockItemCommands
{
    public class CreateStockItemCommand : IRequest<Response<StockItemDto>>
    {
        public int Quantity { get; set; }
    }
}
