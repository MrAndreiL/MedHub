using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceQueries;

namespace MedHub.Application.Handlers.InvoiceHandlers
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Response<InvoiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetInvoiceByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<InvoiceDto>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedInvoice = await unitOfWork.InvoiceRepository.FindByIdAsync(request.Id);
            if (searchedInvoice == null)
            {
                return Response<InvoiceDto>.Create(OperationState.NotFound);
            }

            var invoiceDto = MedHubMapper.Mapper.Map<InvoiceDto>(searchedInvoice);
            if (invoiceDto == null)
            {
                return Response<InvoiceDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Invoice to InvoiceDto.");
            }

            return Response<InvoiceDto>.Create(OperationState.Done, invoiceDto);
        }
    }
}
