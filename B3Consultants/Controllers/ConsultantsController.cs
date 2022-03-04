using Microsoft.AspNetCore.Mvc;
using B3Consultants.Entities;
using B3Consultants.DB;
using Microsoft.EntityFrameworkCore;
using B3Consultants.Services;
using B3Consultants.EntitiesDTOs;
using Microsoft.AspNetCore.Authorization;

namespace B3Consultants.Controllers
{
    [ApiController]
    [Route("consultants")]
    [Authorize]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService _service;
        private readonly ILogger<ConsultantsController> _logger;

        public ConsultantsController(ILogger<ConsultantsController> logger, IConsultantService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ConsultantDTO> GetConsultants()
        {
            var consultants = _service.GetConsultants();
            return consultants;
        }

        [HttpPost("addConsultant")]
        public ActionResult AddConsultant([FromBody] AddConsultantDTO consultantDTO)
        {
            _service.AddConsultant(consultantDTO);
            
            return Created($"/consultants/{consultantDTO.FirstName} {consultantDTO.LastName}", null);
        }

        [HttpPatch("modfiyConsultant{id}")]
        public ActionResult ModifyConsultant([FromRoute] int id, [FromBody] AddConsultantDTO consultantDTO)
        {
            _service.ModifyConsultant(consultantDTO, id);

            return Ok();

        }

        [HttpDelete("removeConsultant{id}")]
        public ActionResult DeleteConsultant([FromRoute] int id)
        {
            _service.DeleteConsultant(id);

            return Ok();
        }
    }
}