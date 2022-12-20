using MedHub.Application.Commands;
using MedHub.Application.Mappers;
using MedHub.Application.Response;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers
{
    public class UpdateAllergenCommandHandler : IRequestHandler<UpdateAllergenCommand, AllergenResponse>
    {
        private readonly IRepository<Allergen> repository;

        public UpdateAllergenCommandHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<AllergenResponse> Handle(UpdateAllergenCommand request, CancellationToken cancellationToken)
        {
            var allergenEntity = MedHubMapper.Mapper.Map<Allergen>(request);
            await repository.Update(allergenEntity);
            return MedHubMapper.Mapper.Map<AllergenResponse>(allergenEntity);
        }
    }
}
