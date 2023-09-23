namespace TwitterApp.Model
{
    public class TweetLike
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Tweet Tweet { get; set; }
        public int TweetId { get; set; }
        public DateTime Liketime { get; set; }

        public TweetLike() { }
    }
}
