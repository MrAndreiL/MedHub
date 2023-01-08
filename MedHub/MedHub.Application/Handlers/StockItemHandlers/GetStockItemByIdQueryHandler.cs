using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.StockItemQueries;

namespace MedHub.Application.Handlers.StockItemHandlers
{
    public class GetStockItemByIdQueryHandler : IRequestHandler<GetStockItemByIdQuery, Response<StockItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetStockItemByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<StockItemDto>> Handle(GetStockItemByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedStockItem = await unitOfWork.StockItemRepository.FindByIdAsync(request.Id);
            if (searchedStockItem == null)
            {
                return Response<StockItemDto>.Create(OperationState.NotFound);
            }

            var stockItemDto = MedHubMapper.Mapper.Map<StockItemDto>(searchedStockItem);
            if (stockItemDto == null)
            {
                return Response<StockItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type StockItem to StockItemDto.");
            }

            return Response<StockItemDto>.Create(OperationState.Done, stockItemDto);
        }
    }
}
