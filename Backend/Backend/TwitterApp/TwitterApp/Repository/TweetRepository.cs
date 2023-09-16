using Microsoft.EntityFrameworkCore;
using TwitterApp.Dto.TweetD;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;
using static TwitterApp.Repository.UserRepository;

namespace TwitterApp.Repository
{
    public class TweetRepository : ITweet
    {
        private readonly TwitterDbContext _context;
        private readonly DbSet<Tweet> _collection;
        private readonly UserRepository _userRepository;
        public TweetRepository(TwitterDbContext context)
        {
            _context = context;
            _collection = _context.Tweets;
        }

        public async Task<Tweet> CreateTweet(Tweet tweet)
        {
            var NewTweet = new Tweet
            {
                UserId = tweet.UserId,
                CreatedAt = DateTime.Now,
                Content = tweet.Content
              };

            await _collection.AddAsync(NewTweet);
            await _context.SaveChangesAsync();
            return NewTweet;
        }


        public async Task< bool> DeleteTweet(Tweet tweet)
        {
            _collection.Remove(tweet);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Tweet> Get(int id)
        {
            return await _collection.AsNoTracking().FirstOrDefaultAsync(tweet => tweet.Id == id);
        }

        public async Task< IEnumerable<Tweet>> GetTweets()
        {
            return await _collection.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TweetResponse>> GetTweetsSearch(string search)
        {
            var query = _context.Tweets
        .Where(t => t.Content.Contains(search))
        .ToList();

            var tweetDtos = query.Select(t => new TweetResponse
            {
                Content = t.Content,
                UserName = _context.Users.FirstOrDefault(u => u.Id == t.UserId)?.UserName
            });
            

            return tweetDtos;
        }

        public async Task<bool> UpdateTweet(Tweet tweet)
        {
            _context.Tweets.Entry(tweet).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
