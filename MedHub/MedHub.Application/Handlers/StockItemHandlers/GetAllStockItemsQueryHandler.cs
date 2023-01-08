using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.StockItemQueries;

namespace MedHub.Application.Handlers.StockItemHandlers
{
    public class GetAllStockItemsQueryHandler : IRequestHandler<GetAllStockItemsQuery, Response<List<StockItemDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllStockItemsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<StockItemDto>>> Handle(GetAllStockItemsQuery request, CancellationToken cancellationToken)
        {
            var stockItems = MedHubMapper.Mapper.Map<List<StockItemDto>>(await unitOfWork.StockItemRepository.GetAllAsync());
            if (stockItems == null)
            {
                return Response<List<StockItemDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<StockItem> to List<StockItemDto>.");
            }

            return Response<List<StockItemDto>>.Create(OperationState.Done, stockItems);
        }
    }
}
