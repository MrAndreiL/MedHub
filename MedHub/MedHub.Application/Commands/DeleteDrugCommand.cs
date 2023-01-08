using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class DeleteDrugCommand : IRequest<Response<DrugDto>>
    {
        public Guid DrugId { get; }

        public DeleteDrugCommand(Guid drugId)
        {
            DrugId = drugId;
        }
    }
}
