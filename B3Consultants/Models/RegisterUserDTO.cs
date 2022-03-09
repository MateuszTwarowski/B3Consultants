namespace B3Consultants.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
        public int UserRoleId { get; set; } = 1;
    }
}
