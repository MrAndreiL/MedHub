using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.PatientCommands;

namespace MedHub.Application.Handlers.PatientHandlers
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Response<PatientDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<PatientDto>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientEntity = MedHubMapper.Mapper.Map<Patient>(request);
            if (patientEntity == null)
            {
                return Response<PatientDto>.Create(OperationState.MappingError, "An error occured while mapping object of type UpdatePatientCommand to Patient.");
            }

            var result = await unitOfWork.PatientRepository.UpdateAsync(patientEntity.Id, patientEntity);
            if (result == null)
            {
                return Response<PatientDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var patientDto = MedHubMapper.Mapper.Map<PatientDto>(patientEntity);
            if (patientDto == null)
            {
                return Response<PatientDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Patient to PatientDto.");
            }

            return Response<PatientDto>.Create(OperationState.Done, patientDto);
        }
    }
}
