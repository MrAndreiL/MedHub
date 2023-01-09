using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.StockItemCommands
{
    public class CreateStockItemCommand : CreateLineItemCommand, IRequest<Response<StockItemDto>> { }
}
