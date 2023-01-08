using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.InvoiceCommands;

namespace MedHub.Application.Handlers.InvoiceHandlers
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Response<InvoiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateInvoiceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<InvoiceDto>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceEntity = MedHubMapper.Mapper.Map<Invoice>(request);
            if (invoiceEntity == null)
            {
                return Response<InvoiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateInvoiceCommand to Invoice.");
            }

            var result = await unitOfWork.InvoiceRepository.UpdateAsync(invoiceEntity.Id, invoiceEntity);
            if (result == null)
            {
                return Response<InvoiceDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var invoiceDto = MedHubMapper.Mapper.Map<InvoiceDto>(invoiceEntity);
            if (invoiceDto == null)
            {
                return Response<InvoiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Invoice to InvoiceDto.");
            }

            return Response<InvoiceDto>.Create(OperationState.Done, invoiceDto);
        }
    }
}
