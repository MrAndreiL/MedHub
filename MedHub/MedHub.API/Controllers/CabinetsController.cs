using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinetsController : ControllerBase
    {
        private readonly IRepository<Cabinet> cabinetRepository;

        public CabinetsController(IRepository<Cabinet> cabinetRepository)
        {
            this.cabinetRepository = cabinetRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(cabinetRepository.GetAll());
        }
    }
}
