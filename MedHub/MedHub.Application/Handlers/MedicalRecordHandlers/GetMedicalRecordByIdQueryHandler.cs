using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.MedicalRecordQueries;

namespace MedHub.Application.Handlers.MedicalRecordHandlers
{
    public class GetMedicalRecordByIdQueryHandler : IRequestHandler<GetMedicalRecordByIdQuery, Response<MedicalRecordDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMedicalRecordByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<MedicalRecordDto>> Handle(GetMedicalRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedMedicalRecord = await unitOfWork.MedicalRecordRepository.FindByIdAsync(request.Id);
            if (searchedMedicalRecord == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.NotFound);
            }

            var medicalRecordDto = MedHubMapper.Mapper.Map<MedicalRecordDto>(searchedMedicalRecord);
            if (medicalRecordDto == null)
            {
                return Response<MedicalRecordDto>.Create(OperationState.MappingError, "An error occured while mapping object of type MedicalRecord to MedicalRecordDto.");
            }

            return Response<MedicalRecordDto>.Create(OperationState.Done, medicalRecordDto);
        }
    }
}
