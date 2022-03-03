using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;

namespace B3Consultants.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        void RegisterUser(RegisterUserDTO UserDTO);
    }
}
