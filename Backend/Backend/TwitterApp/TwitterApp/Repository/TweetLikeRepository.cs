using Microsoft.EntityFrameworkCore;
using TwitterApp.Dto.Likes;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;

namespace TwitterApp.Repository
{
    public class TweetLikeRepository : ITweetLike
    {
        private readonly TwitterDbContext _context;
        private readonly DbSet<TweetLike> _collection;

        public TweetLikeRepository(TwitterDbContext context)
        {
            _context = context;
            _collection = _context.TweetsLike;
            
        }

        public async Task<bool> IsLike(int tweetId, int userId)
        {
            try
            {
                
                bool isLiked = await _context.TweetsLike
                    .AnyAsync(like => like.Tweet.Id == tweetId && like.UserId == userId);

                return isLiked;
            }
            catch (Exception ex)
            {

                return false ;
            }
        }

        public async Task<bool> LikeTweet(TweetLike tweetLike)
        {
            
            if(!await IsLike(tweetLike.TweetId,tweetLike.UserId)) {
                var newlike = new TweetLike
                {
                    UserId = tweetLike.UserId,
                    TweetId = tweetLike.TweetId,
                    Liketime = DateTime.Now,
                };
                await _collection.AddAsync(newlike);
                await _context.SaveChangesAsync();
                return true;
            }

            _collection.Remove(tweetLike);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
