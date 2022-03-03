using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;

namespace B3Consultants.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        void AddRole(AddRoleDTO RoleDTO);
        void ModifyRole(AddRoleDTO RoleDTO, int id);
        void DeleteRole(int id);
    }
}
