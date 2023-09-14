using System.ComponentModel.DataAnnotations;

namespace TwitterApp.Dto
{
    public class LoginUserRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
