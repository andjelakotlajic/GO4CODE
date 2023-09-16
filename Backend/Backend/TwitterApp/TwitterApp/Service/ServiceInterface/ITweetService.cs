using TwitterApp.Dto.TweetD;
using TwitterApp.Model;

namespace TwitterApp.Service.ServiceInterface
{
    public interface ITweetService
    {
       public  Task<TweetResponse> CreateTweet(TweetResponse tweet);
       public Task<bool> UpdateTweet(TweetPut tweet);

        public Task<bool>  DeleteTweet (int id);

       public Task<IEnumerable<TweetResponse>> GetTweets();

        public Task<IEnumerable<TweetResponse>> GetTweetsSearch(string search);
    }
}
