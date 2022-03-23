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
    [Route("experiences")]
    [Authorize]
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
        [AllowAnonymous]
        public IEnumerable<Experience> GetExperiences()
        {
            var experiences = _service.GetExperiences();
            return experiences;
        }
        [HttpPost("addExperience")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddExperience([FromBody] AddExperienceDTO experienceDTO)
        {
            _service.AddExperience(experienceDTO);
            return Ok();
        }

        [HttpPatch("modfiyExperience{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult ModifyExperience([FromRoute] int id, [FromBody] AddExperienceDTO experienceDTO)
        {
            _service.ModifyExperience(experienceDTO, id);

            return Ok();

        }

        [HttpDelete("removeExperience{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteExperience([FromRoute] int id)
        {
            _service.DeleteExperience(id);

            return Ok();
        }
    }
}
