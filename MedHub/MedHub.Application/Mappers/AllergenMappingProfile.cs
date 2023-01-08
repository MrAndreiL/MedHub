using AutoMapper;
using MedHub.Application.Commands.AllergenCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class AllergenMappingProfile : Profile
    {
        public AllergenMappingProfile()
        {
            CreateMap<Allergen, AllergenDto>().ReverseMap();
            CreateMap<Allergen, CreateAllergenCommand>().ReverseMap();
            CreateMap<Allergen, UpdateAllergenCommand>().ReverseMap();
        }
    }
}
