using MedHub.Application.Commands.InvoiceItemCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.InvoiceItemHandlers
{
    public class CreateInvoiceItemCommandHandler : IRequestHandler<CreateInvoiceItemCommand, Response<InvoiceItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateInvoiceItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<InvoiceItemDto>> Handle(CreateInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            var invoiceItemEntity = MedHubMapper.Mapper.Map<InvoiceItem>(request);
            if (invoiceItemEntity == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateInvoiceItemCommand to InvoiceItem.");
            }

            var createdInvoiceItem = await unitOfWork.InvoiceItemRepository.AddAsync(invoiceItemEntity);
            await unitOfWork.SaveChangesAsync();

            var createdInvoiceItemDto = MedHubMapper.Mapper.Map<InvoiceItemDto>(createdInvoiceItem);
            if (createdInvoiceItemDto == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type InvoiceItem to InvoiceItemDto.");
            }

            return Response<InvoiceItemDto>.Create(OperationState.Done, createdInvoiceItemDto);
        }
    }
}
