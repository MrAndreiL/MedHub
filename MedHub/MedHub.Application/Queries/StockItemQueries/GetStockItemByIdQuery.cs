using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.StockItemQueries
{
    public class GetStockItemByIdQuery : IdCommandQuery, IRequest<Response<StockItemDto>>
    {
        public GetStockItemByIdQuery(Guid id) : base(id) { }
    }
}
