using Microsoft.AspNetCore.Mvc;
using MyShop.Infrastructure;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public MedicalRecordsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = unitOfWork.MedicalRecordRepository.GetAll;
            return Ok(result);
        }
    }
}
