using B3Consultants.EntitiesDTOs;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _service.GetUsers();
            return users;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDTO userDTO)
        {
            _service.RegisterUser(userDTO);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult LoginUser([FromBody]LoginUserDTO userDTO)
        {
            string token = _service.GenereteJwt(userDTO);
            return Ok(token);
        }
    }
}