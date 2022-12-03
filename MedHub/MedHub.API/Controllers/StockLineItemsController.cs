using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class StockLineItemsController : ControllerBase
    {
        private readonly IRepository<StockLineItem> stockLineItemRepository;

        public StockLineItemsController(IRepository<StockLineItem> stockLineItemRepository)
        {
            this.stockLineItemRepository = stockLineItemRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(stockLineItemRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create()
        {
            var stockLineItem = new StockLineItem();
            stockLineItemRepository.Add(stockLineItem);
            stockLineItemRepository.SaveChanges();
            return Created(nameof(Get), stockLineItem);
        }
    }
}
