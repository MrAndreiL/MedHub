using MedHub.Application.Commands.PatientCommands;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Mappers;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers.PatientHandlers
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Response<PatientDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<PatientDto>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientEntity = MedHubMapper.Mapper.Map<Patient>(request);
            if (patientEntity == null)
            {
                return Response<PatientDto>.Create(OperationState.MappingError, "An error occured while mapping object of type CreatePatientCommand to Patient.");
            }

            var createdPatient = await unitOfWork.PatientRepository.AddAsync(patientEntity);
            await unitOfWork.SaveChangesAsync();

            var createdPatientDto = MedHubMapper.Mapper.Map<PatientDto>(createdPatient);
            if (createdPatientDto == null)
            {
                return Response<PatientDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Patient to PatientDto.");
            }

            return Response<PatientDto>.Create(OperationState.Done, createdPatientDto);
        }
    }
}
