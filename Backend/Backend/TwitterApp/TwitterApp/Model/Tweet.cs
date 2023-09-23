namespace TwitterApp.Model
{
    public class Tweet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public ICollection<TweetLike> Likes { get; set; } = new List<TweetLike>();

        public Tweet() { }
    }
}
