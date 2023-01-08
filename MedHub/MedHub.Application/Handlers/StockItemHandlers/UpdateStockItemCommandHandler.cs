using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.StockItemCommands;

namespace MedHub.Application.Handlers.StockItemHandlers
{
    public class UpdateStockItemCommandHandler : IRequestHandler<UpdateStockItemCommand, Response<StockItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateStockItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<StockItemDto>> Handle(UpdateStockItemCommand request, CancellationToken cancellationToken)
        {
            var stockItemEntity = MedHubMapper.Mapper.Map<StockItem>(request);
            if (stockItemEntity == null)
            {
                return Response<StockItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateStockItemCommand to StockItem.");
            }

            var result = await unitOfWork.StockItemRepository.UpdateAsync(stockItemEntity.Id, stockItemEntity);
            if (result == null)
            {
                return Response<StockItemDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var stockItemDto = MedHubMapper.Mapper.Map<StockItemDto>(stockItemEntity);
            if (stockItemDto == null)
            {
                return Response<StockItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type StockItem to StockItemDto.");
            }

            return Response<StockItemDto>.Create(OperationState.Done, stockItemDto);
        }
    }
}
