using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.StockItemCommands;

namespace MedHub.Application.Handlers.StockItemHandlers
{
    public class DeleteStockItemCommandHandler : IRequestHandler<DeleteStockItemCommand, Response<StockItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteStockItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<StockItemDto>> Handle(DeleteStockItemCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.StockItemRepository.DeleteAsync(request.Id);
            if (result == null)
            {
                return Response<StockItemDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var stockItemDto = MedHubMapper.Mapper.Map<StockItemDto>(result);
            if (stockItemDto == null)
            {
                return Response<StockItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type StockItem to StockItemDto.");
            }

            return Response<StockItemDto>.Create(OperationState.Done, stockItemDto);
        }
    }
}
