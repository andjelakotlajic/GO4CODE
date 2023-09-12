namespace BackendProject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Bio { get; set; }

        public DateTime? DateOfBirth { get; set; }
        
        public ICollection<User> Followers { get; set; }
        public ICollection<User> Following { get; set; }

        public ICollection<Tweet> Tweets { get; set; } = new List<Tweet>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public User() { 
        
        }

    }
}
