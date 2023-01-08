using AutoMapper;
using MedHub.Application.Commands.InvoiceItemCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class InvoiceItemMappingProfile : Profile
    {
        public InvoiceItemMappingProfile()
        {
            CreateMap<InvoiceItem, InvoiceItemDto>().ReverseMap();
            CreateMap<InvoiceItem, CreateInvoiceItemCommand>().ReverseMap();
            CreateMap<InvoiceItem, UpdateInvoiceItemCommand>().ReverseMap();
        }
    }
}
