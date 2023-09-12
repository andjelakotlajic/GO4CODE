namespace BackendProject.Dto.UserD
{
    public class UserDtoAdd
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Bio { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
