using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
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
            var cabinet = Cabinet.Create(cabinetDto.Address);
            if (cabinet.IsSuccess)
            {
                cabinetRepository.Add(cabinet.Entity);

                var fullCabinet = new CabinetDto
                {
                    Id = cabinet.Entity.Id,
                    Address= cabinet.Entity.Address
                };

                return Created(nameof(Get), fullCabinet);
            }

            return BadRequest(cabinet.Error);
        }
    }
}
