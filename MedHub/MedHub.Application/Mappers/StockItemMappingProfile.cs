using AutoMapper;
using MedHub.Application.Commands.StockItemCommands;
using MedHub.Application.DTOs;
using MedHub.Core.Entities;

namespace MedHub.Application.Mappers
{
    public class StockItemMappingProfile : Profile
    {
        public StockItemMappingProfile()
        {
            CreateMap<StockItem, StockItemDto>().ReverseMap();
            CreateMap<StockItem, CreateStockItemCommand>().ReverseMap();
            CreateMap<StockItem, UpdateStockItemCommand>().ReverseMap();
        }
    }
}
