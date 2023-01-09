using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetDrugByIdQuery : IdDto, IRequest<Response<DrugDto>>
    {
        public GetDrugByIdQuery(Guid id) : base(id) { }
    }
}
