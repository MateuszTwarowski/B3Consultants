using B3Consultants.DB;
using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using B3Consultants.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace B3Consultants.Services
{
    public class UserService : IUserService
    {
        private ConsultantDBContext _dBContext;
        private IMapper _mapper;
        private ILogger _logger;
        private IPasswordHasher<User> _passwordHasher;
        public UserService(ConsultantDBContext dBContext, IMapper mapper, ILogger<UserService> logger, IPasswordHasher<User> passwordhasher)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordhasher;
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _dBContext.Users
                .Include(r => r.UserRole)
                .ToList();
            var usersDTOs = _mapper.Map<List<UserDTO>>(users);

            return usersDTOs;
        }

        public void RegisterUser(RegisterUserDTO UserDTO)
        {
            var user = _mapper.Map<User>(UserDTO);
            var hashedpassword = _passwordHasher.HashPassword(user, user.PasswordHash);
            user.PasswordHash = hashedpassword;

            _dBContext.Users.Add(user);
            _dBContext.SaveChanges();
        }
    }
}
