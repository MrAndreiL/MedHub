using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.MedicalRecordQueries;

namespace MedHub.Application.Handlers.MedicalRecordHandlers
{
    public class GetAllMedicalRecordsQueryHandler : IRequestHandler<GetAllMedicalRecordsQuery, Response<List<MedicalRecordDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllMedicalRecordsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<MedicalRecordDto>>> Handle(GetAllMedicalRecordsQuery request, CancellationToken cancellationToken)
        {
            var medicalRecords = MedHubMapper.Mapper.Map<List<MedicalRecordDto>>(await unitOfWork.MedicalRecordRepository.GetAllAsync());
            if (medicalRecords == null)
            {
                return Response<List<MedicalRecordDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<MedicalRecord> to List<MedicalRecordDto>.");
            }

            return Response<List<MedicalRecordDto>>.Create(OperationState.Done, medicalRecords);
        }
    }
}
