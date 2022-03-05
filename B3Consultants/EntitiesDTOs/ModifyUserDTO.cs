namespace B3Consultants.EntitiesDTOs
{
    public class ModifyUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int UserRoleId { get; set; }
    }
}
