using MedHub.Application.Commands;
using MedHub.Application.Mappers;
using MedHub.Application.Response;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers
{
    public class CreateAllergenCommandHandler : IRequestHandler<CreateAllergenCommand, AllergenResponse>
    {
        private readonly IRepository<Allergen> repository;

        public CreateAllergenCommandHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }

        public async Task<AllergenResponse> Handle(CreateAllergenCommand request, CancellationToken cancellationToken)
        {
            var allergenEntity = MedHubMapper.Mapper.Map<Allergen>(request);
            var newAllergen = await repository.AddAsync(allergenEntity);
            return MedHubMapper.Mapper.Map<AllergenResponse>(newAllergen);
        }
    }
}
