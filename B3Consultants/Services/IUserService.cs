using B3Consultants.Entities;
using B3Consultants.Models;

namespace B3Consultants.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        void RegisterUser(RegisterUserDTO UserDTO);
        string GenereteJwt(LoginUserDTO userDTO);
        public void ModifyUser(ModifyUserDTO modifyUserDTO, int id);
        public void DeleteUser(int id);
    }
}
