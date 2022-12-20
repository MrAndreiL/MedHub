using AutoMapper;
using MedHub.Application.Commands;
using MedHub.Application.Response;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class AllergenMappingProfile : Profile
    {
        public AllergenMappingProfile()
        {
            CreateMap<Allergen, AllergenResponse>().ReverseMap();
            CreateMap<Allergen, CreateAllergenCommand>().ReverseMap();
            CreateMap<Allergen, UpdateAllergenCommand>().ReverseMap();
        }
    }
}
