using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceQueries;

namespace MedHub.Application.Handlers.InvoiceHandlers
{
    public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, Response<List<InvoiceDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllInvoicesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<InvoiceDto>>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = MedHubMapper.Mapper.Map<List<InvoiceDto>>(await unitOfWork.InvoiceRepository.GetAllAsync());
            if (invoices == null)
            {
                return Response<List<InvoiceDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Invoice> to List<InvoiceDto>.");
            }

            return Response<List<InvoiceDto>>.Create(OperationState.Done, invoices);
        }
    }
}
