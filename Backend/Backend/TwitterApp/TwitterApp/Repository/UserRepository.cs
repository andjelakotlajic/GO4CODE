using TwitterApp.Model;
using TwitterApp.Repository.Interface;

namespace TwitterApp.Repository
{
    public class UserRepository : IUser
    {
        private readonly TwitterDbContext _context;
        public UserRepository(TwitterDbContext context)
        {
            _context = context;
        }



        public  User CreateUser(User user)
        {
            var NewUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                UserName = user.UserName,
                Password = user.Password
            };
            _context.Users.Add(NewUser);
            _context.SaveChanges();
            return user;
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
        public bool UpdateUser(User user)
        {

            //_context.Users.Entry(user).State = EntityState.Modified;
            //_context.SaveChanges();

            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            
            if (existingUser != null)
            {
                existingUser = GetUserByUsername(existingUser.UserName);
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Bio = user.Bio;
                _context.SaveChanges();
                return true;
            }
            return false;

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

        public int GetUserId(string username)
        {
            var user =  _context.Users.FirstOrDefault(u => u.UserName == username);
            return user.Id;
        }

        public string GetUserName(int userId)
        {
           var user = _context.Users.FirstOrDefault(u=> u.Id == userId);
            return user.UserName;
        }
    }
    }

