using B3Consultants.DB;
using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using B3Consultants.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace B3Consultants.Services
{
    public class UserService : IUserService
    {
        private ConsultantDBContext _dBContext;
        private IMapper _mapper;
        private ILogger _logger;
        private IPasswordHasher<User> _passwordHasher;
        private AuthenticationSettings _authenticationSettings;

        public UserService(ConsultantDBContext dBContext, IMapper mapper, ILogger<UserService> logger, IPasswordHasher<User> passwordhasher, AuthenticationSettings authenticationSettings)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordhasher;
            _authenticationSettings = authenticationSettings;
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _dBContext.Users
                .Include(r => r.UserRole)
                .ToList();
            var usersDTOs = _mapper.Map<List<UserDTO>>(users);

            return usersDTOs;
        }

        public void RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var user = _mapper.Map<User>(registerUserDTO);
            var hashedpassword = _passwordHasher.HashPassword(user, user.PasswordHash);
            user.PasswordHash = hashedpassword;

            _dBContext.Users.Add(user);
            _dBContext.SaveChanges();
        }

        public string GenereteJwt(LoginUserDTO userDTO)
        {
            var user = _dBContext.Users
                .Include(x => x.UserRole)
                .FirstOrDefault(x => x.Email == userDTO.Email);

            if (user == null)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userDTO.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.UserRole.UserRoleTitle}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
        public void ModifyUser(ModifyUserDTO modifyUserDTO, int id)
        {
            var user = _dBContext.Users.FirstOrDefault(x => x.Id == id);
            user.FirstName = modifyUserDTO.FirstName;
            user.LastName = modifyUserDTO?.LastName;
            user.Email = modifyUserDTO?.Email;
            user.PhoneNumber = modifyUserDTO?.PhoneNumber;
            user.PasswordHash = modifyUserDTO?.PasswordHash;
            user.UserRoleId = modifyUserDTO.UserRoleId;

            var hashedpassword = _passwordHasher.HashPassword(user, user.PasswordHash);
            user.PasswordHash = hashedpassword;

            _dBContext.Users.Update(user);
            _dBContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dBContext.Users.FirstOrDefault(x => x.Id == id);

            _dBContext.Users.Remove(user);
            _dBContext.SaveChanges();
        }

    }
}
