using Microsoft.AspNetCore.Mvc;
using B3Consultants.Entities;
using B3Consultants.DB;
using Microsoft.EntityFrameworkCore;
using B3Consultants.Services;
using B3Consultants.Models;
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
        [AllowAnonymous]
        public PagedResult<ConsultantDTO> GetConsultants([FromQuery] ConsultantQuery query)
        {
            var consultants = _service.GetConsultants(query);
            return consultants;
        }

        [HttpGet("byId/{id}")]
        [AllowAnonymous]
        public ConsultantDTO GetConsultantsById([FromRoute]int id)
        {
            var consultant = _service.GetConsultantsById(id);
            return consultant;
        }

        [HttpPost("addConsultant")] 
        [AllowAnonymous]
        //[Authorize(Roles = "Business Manager, Admin")]
        public ActionResult AddConsultant([FromBody] AddConsultantDTO consultantDTO)
        {
            _service.AddConsultant(consultantDTO);

            return Ok();
        }

        [HttpPut("modfiyConsultant{id}")]
        [AllowAnonymous]
        //[Authorize(Roles = "Business Manager, Admin")]
        public ActionResult ModifyConsultant([FromRoute] int id, [FromBody] AddConsultantDTO consultantDTO)
        {
            _service.ModifyConsultant(consultantDTO, id);

            return Ok();

        }

        [HttpDelete("removeConsultant{id}")]
        [AllowAnonymous]
        //[Authorize(Roles = "Business Manager, Admin")]
        public ActionResult DeleteConsultant([FromRoute] int id)
        {
            _service.DeleteConsultant(id);

            return Ok();
        }
    }
}