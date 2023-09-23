using TwitterApp.Model;

namespace TwitterApp.Dto.TweetD
{
    public class TweetsResponse
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public ICollection<TweetLike> Likes { get; set; } = new List<TweetLike>();
    }
}
