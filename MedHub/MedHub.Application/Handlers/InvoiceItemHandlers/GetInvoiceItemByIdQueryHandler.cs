using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceItemQueries;

namespace MedHub.Application.Handlers.InvoiceItemHandlers
{
    public class GetInvoiceItemByIdQueryHandler : IRequestHandler<GetInvoiceItemByIdQuery, Response<InvoiceItemDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetInvoiceItemByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<InvoiceItemDto>> Handle(GetInvoiceItemByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedInvoiceItem = await unitOfWork.InvoiceItemRepository.FindByIdAsync(request.Id);
            if (searchedInvoiceItem == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.NotFound);
            }

            var invoiceItemDto = MedHubMapper.Mapper.Map<InvoiceItemDto>(searchedInvoiceItem);
            if (invoiceItemDto == null)
            {
                return Response<InvoiceItemDto>.Create(OperationState.MappingError, "An error occured while mapping object of type InvoiceItem to InvoiceItemDto.");
            }

            return Response<InvoiceItemDto>.Create(OperationState.Done, invoiceItemDto);
        }
    }
}
