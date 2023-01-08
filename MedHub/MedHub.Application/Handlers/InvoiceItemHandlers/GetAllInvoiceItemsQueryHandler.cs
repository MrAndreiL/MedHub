using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceItemQueries;

namespace MedHub.Application.Handlers.InvoiceItemHandlers
{
    public class GetAllInvoiceItemsQueryHandler : IRequestHandler<GetAllInvoiceItemsQuery, Response<List<InvoiceItemDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllInvoiceItemsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<InvoiceItemDto>>> Handle(GetAllInvoiceItemsQuery request, CancellationToken cancellationToken)
        {
            var invoiceItems = MedHubMapper.Mapper.Map<List<InvoiceItemDto>>(await unitOfWork.InvoiceItemRepository.GetAllAsync());
            if (invoiceItems == null)
            {
                return Response<List<InvoiceItemDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<InvoiceItem> to List<InvoiceItemDto>.");
            }

            return Response<List<InvoiceItemDto>>.Create(OperationState.Done, invoiceItems);
        }
    }
}
