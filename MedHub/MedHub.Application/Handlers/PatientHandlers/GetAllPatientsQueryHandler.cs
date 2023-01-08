using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.PatientQueries;

namespace MedHub.Application.Handlers.PatientHandlers
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, Response<List<PatientDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllPatientsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<PatientDto>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = MedHubMapper.Mapper.Map<List<PatientDto>>(await unitOfWork.PatientRepository.GetAllAsync());
            if (patients == null)
            {
                return Response<List<PatientDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Patient> to List<PatientDto>.");
            }

            return Response<List<PatientDto>>.Create(OperationState.Done, patients);
        }
    }
}
