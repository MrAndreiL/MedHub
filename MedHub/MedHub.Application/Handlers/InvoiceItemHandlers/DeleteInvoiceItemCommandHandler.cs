using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.InvoiceItemCommands;

namespace MedHub.Application.Handlers.InvoiceItemHandlers
{
    public class DeleteInvoiceItemCommandHandler : IRequestHandler<DeleteInvoiceItemCommand, Response<InvoiceItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteInvoiceItemCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<InvoiceItemDto>> Handle(DeleteInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.InvoiceItemRepository.DeleteAsync(request.Id);
            if (result == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var InvoiceItemDto = MedHubMapper.Mapper.Map<InvoiceItemDto>(result);
            if (InvoiceItemDto == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type InvoiceItem to InvoiceItemDto.");
            }

            return Response<InvoiceItemDto>.Create(OperationState.Done, InvoiceItemDto);
        }
    }
}
