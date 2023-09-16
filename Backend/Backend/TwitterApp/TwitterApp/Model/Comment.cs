namespace TwitterApp.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }
        public DateTime CreatedTime { get; set; }

        public int TweetId { get; set; }
        public User User { get; set;}

        public Comment() { }
    }
}
