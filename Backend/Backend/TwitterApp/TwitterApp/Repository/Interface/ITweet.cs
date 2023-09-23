using TwitterApp.Dto.TweetD;
using TwitterApp.Model;

namespace TwitterApp.Repository.Interface
{
    public interface ITweet
    {
        public Task<Tweet> CreateTweet (Tweet tweet);
        public Task<bool> UpdateTweet(Tweet tweet);

        public Task<bool> DeleteTweet(Tweet tweet);

        public Task<IEnumerable<Tweet>> GetTweets(int userid);

        public Task<IEnumerable<TweetsRequest>> GetTweetsSearch(String search);

        public Task<Tweet> Get(int id);
        public Task< IEnumerable<Tweet>> GetAllTweetsByUserId(int userId);
    }
}
