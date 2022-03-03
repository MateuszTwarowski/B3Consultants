namespace B3Consultants.EntitiesDTOs
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserDTO
    {
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(12)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string PasswordHash { get; set; }
        [Required]
        public int UserRoleId { get; set; } = 1;
    }
}
