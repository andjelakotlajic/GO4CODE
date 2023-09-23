namespace TwitterApp.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }
        public DateTime CreatedTime { get; set; }

        public Tweet Tweet { get; set; }
        public int TweetId { get; set; }
        public User User { get; set;}
        public int UserId { get; set; }
        public Comment() { }
    }
}
