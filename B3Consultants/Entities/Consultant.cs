namespace B3Consultants.Entities
{
    public class Consultant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int ExperienceId { get; set; }
        public int HourlyRatePlnNet { get; set; }
        public string Location { get; set; }
        public int AvailabilityId { get; set; }
        public string Description { get; set; }
        public string ProfileSource { get; set; }

        public virtual Role Role { get; set; }
        public virtual Experience Experience { get; set; }
        public virtual Availability Availability { get; set; }

    }
}
