using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.StockItemQueries
{
    public class GetAllStockItemsQuery : IRequest<Response<List<StockItemDto>>>
    {
    }
}
