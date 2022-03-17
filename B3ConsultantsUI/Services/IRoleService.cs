using B3Consultants.Entities;

namespace B3ConsultantsUI.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
    }
}
