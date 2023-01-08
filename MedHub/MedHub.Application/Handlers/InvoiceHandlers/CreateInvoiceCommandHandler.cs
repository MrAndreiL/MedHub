using MedHub.Application.Commands.InvoiceCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.InvoiceHandlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Response<InvoiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateInvoiceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<InvoiceDto>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceEntity = MedHubMapper.Mapper.Map<Invoice>(request);
            if (invoiceEntity == null)
            {
                return Response<InvoiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateInvoiceCommand to Invoice.");
            }

            var createdInvoice = await unitOfWork.InvoiceRepository.AddAsync(invoiceEntity);
            await unitOfWork.SaveChangesAsync();

            var createdInvoiceDto = MedHubMapper.Mapper.Map<InvoiceDto>(createdInvoice);
            if (createdInvoiceDto == null)
            {
                return Response<InvoiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Invoice to InvoiceDto.");
            }

            return Response<InvoiceDto>.Create(OperationState.Done, createdInvoiceDto);
        }
    }
}
