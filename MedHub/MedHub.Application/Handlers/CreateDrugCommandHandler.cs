using MedHub.Application.Commands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers
{
    public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Response<DrugDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateDrugCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<DrugDto>> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
        {
            var drugEntity = MedHubMapper.Mapper.Map<Drug>(request);
            if (drugEntity == null)
            {
                return Response<DrugDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreateDrugCommand to Drug.");
            }

            var createdDrug = await unitOfWork.DrugRepository.AddAsync(drugEntity);
            await unitOfWork.SaveChangesAsync();

            var createdDrugDto = MedHubMapper.Mapper.Map<DrugDto>(createdDrug);
            if (createdDrugDto == null)
            {
                return Response<DrugDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Drug to DrugDto.");
            }

            return Response<DrugDto>.Create(OperationState.Done, createdDrugDto);
        }
    }
}
