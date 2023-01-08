using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.InvoiceCommands;

namespace MedHub.Application.Handlers.InvoiceHandlers
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Response<InvoiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteInvoiceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<InvoiceDto>> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.InvoiceRepository.DeleteAsync(request.Id);
            if (result == null)
            {
                return Response<InvoiceDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var InvoiceDto = MedHubMapper.Mapper.Map<InvoiceDto>(result);
            if (InvoiceDto == null)
            {
                return Response<InvoiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Invoice to InvoiceDto.");
            }

            return Response<InvoiceDto>.Create(OperationState.Done, InvoiceDto);
        }
    }
}
