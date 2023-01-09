using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.StockItemCommands
{
    public class DeleteStockItemCommand : IdDto, IRequest<Response<StockItemDto>>
    {
        public DeleteStockItemCommand(Guid id) : base(id) { }
    }
}
