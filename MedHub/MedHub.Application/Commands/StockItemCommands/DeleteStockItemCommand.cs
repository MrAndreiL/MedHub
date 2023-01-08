using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.StockItemCommands
{
    public class DeleteStockItemCommand : IdCommandQuery, IRequest<Response<StockItemDto>>
    {
        public DeleteStockItemCommand(Guid id) : base(id) { }
    }
}
