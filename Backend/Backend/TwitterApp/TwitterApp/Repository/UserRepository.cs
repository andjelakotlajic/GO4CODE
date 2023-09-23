using Microsoft.EntityFrameworkCore;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;
using static TwitterApp.Repository.TweetRepository;

namespace TwitterApp.Repository
{
    public class UserRepository : IUser
    {
        private readonly TwitterDbContext _context;
        private readonly DbSet<User> _collection;
        private readonly TweetRepository _tweetRepository;
        public UserRepository(TwitterDbContext context,TweetRepository tweetRepository)
        {
            _context = context;
            _collection = _context.Users;
            _tweetRepository = tweetRepository;
        }



        public async Task<User> CreateUser(User user)
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
           await _context.Users.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return NewUser;
        }
        public async Task<User> GetUserByUsername(string username)
        {

            var users =  _context.Users.FirstOrDefault(u => u.UserName == username);

            if (users != null) {
                var tweets = await _tweetRepository.GetAllTweetsByUserId(users.Id);
                foreach(var tweet in tweets)
                {
                    users.Tweets.Add(tweet);
                }
                return users;
            } 

            
            return null;
        }
        public async Task DeleteUser(string username)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == username);

            var tweets = await _tweetRepository.GetAllTweetsByUserId(existingUser.Id);

            if (tweets != null)
            {
                foreach (var tweet in tweets)
                {
                  await _tweetRepository.DeleteTweet(tweet);
                }
            }

            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChangesAsync();
            }
        }
        public async Task<bool> UpdateUser(User user)
        {

            //_context.Users.Entry(user).State = EntityState.Modified;
            //_context.SaveChanges();

            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            
            if (existingUser != null)
            {
                existingUser = await GetUserByUsername(existingUser.UserName);
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Bio = user.Bio;
               await _context.SaveChangesAsync();
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

        public async Task<IEnumerable<Tweet>> GetTweets(int id)
        {
            var tweets = await _context.Tweets.Where(t => t.UserId == id).ToListAsync();
            return tweets;

        }




        public void UnfollowUser(User userToUnfollow)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetUserId(string username)
        {
            var user =  _context.Users.FirstOrDefault(u => u.UserName == username);
            var userid = user.Id;
            return  userid;
        }

        public async Task<string> GetUserName(int userId)
        {
           var user = _context.Users.FirstOrDefault(u=> u.Id == userId);
            return  user.UserName;
        }

    }
    }

