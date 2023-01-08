using MedHub.Application.Commands.StockItemCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.StockItemHandlers
{
    public class CreateStockItemCommandHandler : IRequestHandler<CreateStockItemCommand, Response<StockItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateStockItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<StockItemDto>> Handle(CreateStockItemCommand request, CancellationToken cancellationToken)
        {
            var stockItemEntity = MedHubMapper.Mapper.Map<StockItem>(request);
            if (stockItemEntity == null)
            {
                return Response<StockItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateStockItemCommand to StockItem.");
            }

            var createdStockItem = await unitOfWork.StockItemRepository.AddAsync(stockItemEntity);
            await unitOfWork.SaveChangesAsync();

            var createdStockItemDto = MedHubMapper.Mapper.Map<StockItemDto>(createdStockItem);
            if (createdStockItemDto == null)
            {
                return Response<StockItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type StockItem to StockItemDto.");
            }

            return Response<StockItemDto>.Create(OperationState.Done, createdStockItemDto);
        }
    }
}
