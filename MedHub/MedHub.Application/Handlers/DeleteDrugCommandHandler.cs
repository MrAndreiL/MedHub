using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands;

namespace MedHub.Application.Handlers
{
    public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand, Response<DrugDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteDrugCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<DrugDto>> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.DrugRepository.DeleteAsync(request.DrugId);
            if (result == null)
            {
                return Response<DrugDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var drugDto = MedHubMapper.Mapper.Map<DrugDto>(result);
            if (drugDto == null)
            {
                return Response<DrugDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Drug to DrugDto.");
            }

            return Response<DrugDto>.Create(OperationState.Done, drugDto);
        }
    }
}
