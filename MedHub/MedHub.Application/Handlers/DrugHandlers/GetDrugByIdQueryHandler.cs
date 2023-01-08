using MedHub.Application.Mappers;
using MedHub.Application.DTOs;
using MedHub.Core.Repositories.Base;
using MediatR;
using MedHub.Application.Helpers;
using MedHub.Application.Queries.InvoiceQueries;

namespace MedHub.Application.Handlers.DrugHandlers
{
    public class GetDrugByIdQueryHandler : IRequestHandler<GetDrugByIdQuery, Response<DrugDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetDrugByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<DrugDto>> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
        {
            var searchedDrug = await unitOfWork.DrugRepository.FindByIdAsync(request.Id);
            if (searchedDrug == null)
            {
                return Response<DrugDto>.Create(OperationState.NotFound);
            }

            var drugDto = MedHubMapper.Mapper.Map<DrugDto>(searchedDrug);
            if (drugDto == null)
            {
                return Response<DrugDto>.Create(OperationState.MappingError, "An error occured while mapping object of type Drug to DrugDto.");
            }

            return Response<DrugDto>.Create(OperationState.Done, drugDto);
        }
    }
}
