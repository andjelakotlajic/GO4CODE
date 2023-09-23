using TwitterApp.Dto.Likes;
using TwitterApp.Model;

namespace TwitterApp.Service.ServiceInterface
{
    public interface ITweetLikeService
    {

        public Task<bool> LikeTweet(TweetLikeDto tweetLike);

    }
}
