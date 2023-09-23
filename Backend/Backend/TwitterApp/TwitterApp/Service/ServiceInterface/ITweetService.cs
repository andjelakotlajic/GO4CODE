using TwitterApp.Dto.TweetD;
using TwitterApp.Model;

namespace TwitterApp.Service.ServiceInterface
{
    public interface ITweetService
    {
       public  Task<TweetsRequest> CreateTweet(TweetsRequest tweet);
       public Task<bool> UpdateTweet(TweetPut tweet);

        public Task<bool>  DeleteTweet (int id);

       public Task<IEnumerable<TweetsResponse>> GetTweets(int userid);

        public Task<IEnumerable<TweetsRequest>> GetTweetsSearch(string search);
    }
}
