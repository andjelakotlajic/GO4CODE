using Microsoft.EntityFrameworkCore;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;
using static TwitterApp.Repository.UserRepository;

namespace TwitterApp.Repository
{
    public class TweetRepository : ITweet
    {
        private readonly TwitterDbContext _context;
        private readonly DbSet<Tweet> _collection;
        public TweetRepository(TwitterDbContext context)
        {
            _context = context;
            _collection = _context.Tweets;
        }

        public async Task< Tweet> CreateTweet(Tweet tweet)
        {
            tweet.CreatedAt = DateTime.Now;

            await _collection.AddAsync(tweet);
            await _context.SaveChangesAsync();
            return tweet;
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

        public async Task<bool> UpdateTweet(Tweet tweet)
        {
            _context.Tweets.Entry(tweet).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
