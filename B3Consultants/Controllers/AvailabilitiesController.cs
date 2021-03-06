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
    [Route("availabilities")]
    [Authorize]
    public class AvailabilitiesController : ControllerBase
    {
        private readonly IAvailabilityService _service;
        private readonly ILogger<AvailabilitiesController> _logger;

        public AvailabilitiesController(ILogger<AvailabilitiesController> logger, IAvailabilityService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Availability> GetAvailabilities()
        {
            var availabilities = _service.GetAvailabilities();
            return availabilities;
        }
        [HttpPost("addAvailability")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddAvailability([FromBody]AddAvailabilityDTO availabilityDTO)
        {
            _service.AddAvailability(availabilityDTO);

            return Ok();
        }

        [HttpPatch("modfiyAvailability{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult ModifyAvailability([FromRoute] int id, [FromBody] AddAvailabilityDTO availabilityDTO)
        {
            _service.ModifyAvailability(availabilityDTO, id);

            return Ok();

        }

        [HttpDelete("removeAvailability{id}")]
        public ActionResult DeleteAvailability([FromRoute] int id)
        {
            _service.DeleteAvailability(id);

            return Ok();
        }
    }
}
