using System.ComponentModel.DataAnnotations;

namespace B3Consultants.EntitiesDTOs
{
    public class AddConsultantDTO
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
        public int RoleId { get; set; }
        [Required]
        public int ExperienceId { get; set; }
        public string Description { get; set; }
        [Required]
        public int HourlyRatePlnNet { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string Location { get; set; }
        [Required]
        public int AvailabilityId { get; set; }
        [Required]
        [Url]
        public string ProfileSource { get; set; }
    }
}
