using AutoMapper;
using MedHub.Application.Commands.MedicalRecordCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class MedicalRecordMappingProfile : Profile
    {
        public MedicalRecordMappingProfile()
        {
            CreateMap<MedicalRecord, MedicalRecordDto>().ReverseMap();
            CreateMap<MedicalRecord, CreateMedicalRecordCommand>().ReverseMap();
            CreateMap<MedicalRecord, UpdateMedicalRecordCommand>().ReverseMap();
        }
    }
}
