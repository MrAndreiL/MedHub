using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceLineItemsController : ControllerBase
    {
        private readonly IRepository<InvoiceLineItem> invoiceLineItemRepository;

        public InvoiceLineItemsController(IRepository<InvoiceLineItem> invoiceLineItemRepository)
        {
            this.invoiceLineItemRepository = invoiceLineItemRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(invoiceLineItemRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create()
        {
            var invoiceLineItem = new InvoiceLineItem();
            invoiceLineItemRepository.Add(invoiceLineItem);
            invoiceLineItemRepository.SaveChanges();
            return Created(nameof(Get), invoiceLineItem);
        }
    }
}
