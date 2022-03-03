﻿using Microsoft.AspNetCore.Mvc;
using B3Consultants.Entities;
using B3Consultants.DB;
using Microsoft.EntityFrameworkCore;
using B3Consultants.Services;
using B3Consultants.EntitiesDTOs;

namespace B3Consultants.Controllers
{
    [ApiController]
    [Route("roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly ILogger<RolesController> _logger;

        public RolesController(ILogger<RolesController> logger, IRoleService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Role> GetRoles()
        {
            var roles = _service.GetRoles();
            return roles;
        }

        [HttpPost("addRole")]
        public ActionResult AddRole([FromBody] AddRoleDTO roleDTO)
        {
            _service.AddRole(roleDTO);

            return Created($"/consultants/{roleDTO.RoleTitle}", null);
        }

        [HttpPatch("modfiyRole{id}")]
        public ActionResult AddRole([FromRoute] int id, [FromBody] AddRoleDTO roleDTO)
        {

            _service.ModifyRole(roleDTO, id);

            return Ok();
        }

        [HttpDelete("removeRole{id}")]
        public ActionResult DeleteRole([FromRoute] int id)
        {
            _service.DeleteRole(id);

            return Ok();
        }
    }
}
