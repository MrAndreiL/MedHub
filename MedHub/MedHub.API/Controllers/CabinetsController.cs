using MedHub.API.DTOs;
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

        [HttpPost]
        public IActionResult Create([FromBody] CreateCabinetDto cabinetDto)
        {
            var cabinet = new Cabinet(cabinetDto.Address);
            cabinetRepository.Add(cabinet);
            cabinetRepository.SaveChanges();
            return Created(nameof(Get), cabinet);
        }
    }
}
