using System.ComponentModel.DataAnnotations;

namespace B3Consultants.EntitiesDTOs
{
    public class AddConsultantDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int ExperienceId { get; set; }
        public string Description { get; set; }
        public int HourlyRatePlnNet { get; set; }
        public string Location { get; set; }
        public int AvailabilityId { get; set; }
        public string ProfileSource { get; set; }
    }
}
