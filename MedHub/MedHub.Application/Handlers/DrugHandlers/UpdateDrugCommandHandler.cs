using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.DrugCommands;

namespace MedHub.Application.Handlers.DrugHandlers
{
    public class UpdateDrugCommandHandler : IRequestHandler<UpdateDrugCommand, Response<DrugDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateDrugCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<DrugDto>> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
        {
            var drugEntity = MedHubMapper.Mapper.Map<Drug>(request);
            if (drugEntity == null)
            {
                return Response<DrugDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdateDrugCommand to Drug.");
            }

            var result = await unitOfWork.DrugRepository.UpdateAsync(drugEntity.Id, drugEntity);
            if (result == null)
            {
                return Response<DrugDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var drugDto = MedHubMapper.Mapper.Map<DrugDto>(drugEntity);
            if (drugDto == null)
            {
                return Response<DrugDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Drug to DrugDto.");
            }

            return Response<DrugDto>.Create(OperationState.Done, drugDto);
        }
    }
}
