using MedHub.Application.Commands;
using MedHub.Application.Mappers;
using MedHub.Application.Response;
using MedHub.Core.Entities;
using MedHub.Core.Repositories.Base;
using MediatR;

namespace MedHub.Application.Handlers
{
    public class DeleteAllergenCommandHandler : IRequestHandler<DeleteAllergenCommand, AllergenResponse>
    {
        private readonly IRepository<Allergen> repository;

        public DeleteAllergenCommandHandler(IRepository<Allergen> repository)
        {
            this.repository = repository;
        }
        public async Task<AllergenResponse> Handle(DeleteAllergenCommand request, CancellationToken cancellationToken)
        {
            var allergenEntity = await repository.GetByIdAsync(request.AllergenId);
            await repository.Delete(allergenEntity);
            return MedHubMapper.Mapper.Map<AllergenResponse>(allergenEntity);
        }
    }
}
