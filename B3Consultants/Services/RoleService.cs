using B3Consultants.DB;
using B3Consultants.Entities;
using B3Consultants.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using B3Consultants.Exceptions;


namespace B3Consultants.Services
{
    public class RoleService : IRoleService
    {
        private ConsultantDBContext _dBContext;
        private IMapper _mapper;
        private ILogger _logger;
        public RoleService(ConsultantDBContext dBContext, IMapper mapper, ILogger<ConsultantService> logger)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = _dBContext.Roles.ToList();
            return roles;
        }
        public void AddRole(AddRoleDTO RoleDTO)
        {
            var role = _mapper.Map<Role>(RoleDTO);
            _dBContext.Roles.Add(role);
            _dBContext.SaveChanges();
        }
        public void ModifyRole(AddRoleDTO RoleDTO, int id)
        {
            var role = _dBContext.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
            {
                throw new NotFoundException("Role not found");
            }
            var roleModified = _mapper.Map<Role>(RoleDTO);
            role.RoleTitle = roleModified.RoleTitle;

            _dBContext.Roles.Update(role);
            _dBContext.SaveChanges();
        }
        public void DeleteRole(int id)
        {

            var role = _dBContext.Roles.FirstOrDefault(x => x.Id == id);

            if (role == null)
            {
                throw new NotFoundException("Role not found");
            }

            _dBContext.Roles.Remove(role);
            _dBContext.SaveChanges();
        }
    }
}
