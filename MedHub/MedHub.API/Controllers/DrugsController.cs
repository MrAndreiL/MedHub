using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly IRepository<Drug> drugRepository;

        public DrugsController(IRepository<Drug> drugRepository)
        {
            this.drugRepository = drugRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(drugRepository.GetAll());
        }
    }
}
