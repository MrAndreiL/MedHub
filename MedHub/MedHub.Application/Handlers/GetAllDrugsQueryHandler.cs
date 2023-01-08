using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries;

namespace MedHub.Application.Handlers
{
    public class GetAllDrugsQueryHandler : IRequestHandler<GetAllDrugsQuery, Response<List<DrugDto>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllDrugsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<DrugDto>>> Handle(GetAllDrugsQuery request, CancellationToken cancellationToken)
        {
            var drugs = MedHubMapper.Mapper.Map<List<DrugDto>>(await unitOfWork.DrugRepository.GetAllAsync());
            if (drugs == null)
            {
                return Response<List<DrugDto>>.Create(OperationState.MappingError, "An error occured while mapping object of type List<Drug> to List<DrugDto>.");
            }

            return Response<List<DrugDto>>.Create(OperationState.Done, drugs);
        }
    }
}
