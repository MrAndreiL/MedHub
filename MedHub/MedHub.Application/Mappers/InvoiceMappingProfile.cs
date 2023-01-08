using AutoMapper;
using MedHub.Application.Commands.InvoiceCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<Invoice, CreateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();
        }
    }
}
