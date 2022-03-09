using B3Consultants.Models;
using Microsoft.AspNetCore.Mvc;
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
    [Route("users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _service.GetUsers();
            return users;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult RegisterUser([FromBody]RegisterUserDTO userDTO)
        {
            _service.RegisterUser(userDTO);
            return Ok();
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult LoginUser([FromBody]LoginUserDTO userDTO)
        {
            string token = _service.GenereteJwt(userDTO);
            return Ok(token);
        }
        [HttpPatch("modifyUser{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult ModifyUsers([FromRoute] int id, [FromBody] ModifyUserDTO modifyUserDTO)
        {
            _service.ModifyUser(modifyUserDTO, id);
            return Ok();
        }
        [HttpDelete("removeUser{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetUsers([FromRoute]int id)
        {
            _service.DeleteUser(id);
            return Ok();
        }
    }
}