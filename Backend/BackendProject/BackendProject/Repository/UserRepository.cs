using BackendProject.Model;
using BackendProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Repository
{
    public class UserRepository : IUser
    {
        private readonly TwitterDbContext _context;
        public UserRepository(TwitterDbContext context)
        {
            _context = context;
        }



        public void CreateUser(User user)
        {
            var NewUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                UserName = user.UserName,
                Password= user.Password
            };
            _context.Users.Add(NewUser);    
            _context.SaveChanges();
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }
        public void DeleteUser(string username)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == username);

            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();
            }
        }
        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {

                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Bio = user.Bio;
                _context.SaveChanges();
            }

        }

        public void FollowUser(User userToFollow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> GetFavoriteTweets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetFollowers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetFollowing()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> GetTweets()
        {
            throw new NotImplementedException();
        }




        public void UnfollowUser(User userToUnfollow)
        {
            throw new NotImplementedException();
        }





 
    }
}
