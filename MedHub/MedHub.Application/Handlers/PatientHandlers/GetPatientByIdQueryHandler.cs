using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.PatientQueries;

namespace MedHub.Application.Handlers.PatientHandlers
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Response<PatientDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<PatientDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedPatient = await unitOfWork.PatientRepository.FindByIdAsync(request.Id);
            if (searchedPatient == null)
            {
                return Response<PatientDto>.Create(OperationState.NotFound);
            }

            var patientDto = MedHubMapper.Mapper.Map<PatientDto>(searchedPatient);
            if (patientDto == null)
            {
                return Response<PatientDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Patient to PatientDto.");
            }

            return Response<PatientDto>.Create(OperationState.Done, patientDto);
        }
    }
}
