using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace TwitterApp.Model
{
    public class User 
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? Bio { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public ICollection<User> Followers { get; set; }
        public ICollection<User> Following { get; set; }

        public ICollection<Tweet> Tweets { get; set; } = new List<Tweet>();
        public ICollection<Favorite> Favorite { get; set; } = new List<Favorite>();
        public User()
        {

        }
    }
}
