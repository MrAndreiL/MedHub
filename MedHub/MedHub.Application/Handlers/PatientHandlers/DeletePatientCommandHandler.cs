using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Commands.PatientCommands;

namespace MedHub.Application.Handlers.PatientHandlers
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Response<PatientDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<PatientDto>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.PatientRepository.DeleteAsync(request.Id);
            if (result == null)
            {
                return Response<PatientDto>.Create(OperationState.NotFound);
            }

            await unitOfWork.SaveChangesAsync();

            var patientDto = MedHubMapper.Mapper.Map<PatientDto>(result);
            if (patientDto == null)
            {
                return Response<PatientDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Patient to PatientDto.");
            }

            return Response<PatientDto>.Create(OperationState.Done, patientDto);
        }
    }
}
