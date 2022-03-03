using Microsoft.AspNetCore.Mvc;
using B3Consultants.Entities;
using B3Consultants.DB;
using Microsoft.EntityFrameworkCore;
using B3Consultants.Services;
using B3Consultants.EntitiesDTOs;

namespace B3Consultants.Controllers
{
    [ApiController]
    [Route("experiences")]
    public class ExperiencesController : ControllerBase
    {
        private readonly IExperienceService _service;
        private readonly ILogger<ExperiencesController> _logger;

        public ExperiencesController(ILogger<ExperiencesController> logger, IExperienceService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Experience> GetExperiences()
        {
            var experiences = _service.GetExperiences();
            return experiences;
        }
        [HttpPost("addExperience")]
        public ActionResult AddExperience([FromBody] AddExperienceDTO experienceDTO)
        {
            _service.AddExperience(experienceDTO);
            return Created($"/experiences/{experienceDTO.ExperienceLevel}", null);
        }

        [HttpPatch("modfiyExperience{id}")]
        public ActionResult ModifyExperience([FromRoute] int id, [FromBody] AddExperienceDTO experienceDTO)
        {
            _service.ModifyExperience(experienceDTO, id);

            return Ok();

        }

        [HttpDelete("removeExperience{id}")]
        public ActionResult DeleteExperience([FromRoute] int id)
        {
            _service.DeleteExperience(id);

            return Ok();
        }
    }
}
