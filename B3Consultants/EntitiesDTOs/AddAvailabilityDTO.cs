using System.ComponentModel.DataAnnotations;

namespace B3Consultants.EntitiesDTOs
{
    public class AddAvailabilityDTO
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string WhenAvailable { get; set; }
    }
}
