using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IRepository<Invoice> invoiceRepository;

        public InvoicesController(IRepository<Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(invoiceRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create()
        {
            var invoice = new Invoice();
            invoiceRepository.Add(invoice);
            invoiceRepository.SaveChanges();
            return Created(nameof(Get), invoice);
        }
    }
}
