﻿using BackendProject.Model;

namespace BackendProject.Dto.UserD
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public ICollection<User> Followers { get; set; }
        public ICollection<User> Following { get; set; }

        public ICollection<Tweet> Tweets { get; set; } = new List<Tweet>();
    }
}
