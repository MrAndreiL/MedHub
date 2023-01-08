using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.InvoiceItemCommands;

namespace MedHub.Application.Handlers.InvoiceItemHandlers
{
    public class UpdateInvoiceItemCommandHandler : IRequestHandler<UpdateInvoiceItemCommand, Response<InvoiceItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateInvoiceItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<InvoiceItemDto>> Handle(UpdateInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            var invoiceItemEntity = MedHubMapper.Mapper.Map<InvoiceItem>(request);
            if (invoiceItemEntity == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateInvoiceItemCommand to InvoiceItem.");
            }

            var result = await unitOfWork.InvoiceItemRepository.UpdateAsync(invoiceItemEntity.Id, invoiceItemEntity);
            if (result == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var invoiceItemDto = MedHubMapper.Mapper.Map<InvoiceItemDto>(invoiceItemEntity);
            if (invoiceItemDto == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type InvoiceItem to InvoiceItemDto.");
            }

            return Response<InvoiceItemDto>.Create(OperationState.Done, invoiceItemDto);
        }
    }
}
