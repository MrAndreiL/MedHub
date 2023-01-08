using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetDrugByIdQuery : IRequest<Response<DrugDto>>
    {
        public Guid DrugId { get; }

        public GetDrugByIdQuery(Guid drugId)
        {
            DrugId = drugId;
        }
    }
}
