namespace B3Consultants.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public string UserRoleTitle { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
