using System.ComponentModel.DataAnnotations;

namespace B3Consultants.Models
{
    public class AddExperienceDTO
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string ExperienceLevel { get; set; }
    }
}
