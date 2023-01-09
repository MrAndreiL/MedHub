using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.StockItemQueries
{
    public class GetStockItemByIdQuery : IdDto, IRequest<Response<StockItemDto>>
    {
        public GetStockItemByIdQuery(Guid id) : base(id) { }
    }
}
