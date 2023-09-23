using TwitterApp.Dto.Likes;
using TwitterApp.Model;

namespace TwitterApp.Repository.Interface
{
    public interface ITweetLike
    {

    

        public Task<bool> IsLike(int tweetId,int userId);
        Task<bool> LikeTweet(TweetLike tweet);
    }
}
