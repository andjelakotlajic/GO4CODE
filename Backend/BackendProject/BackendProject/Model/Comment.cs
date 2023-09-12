using System.Data;

namespace BackendProject.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Tweet_id { get; set;}

        public string CommentText { get; set;}
        public DateTime CreatedTime {  get; set; }
        
        public ICollection<TweetLike> TweetLikes { get; set; } = new List<TweetLike>();
        
        public Comment() { }
    }
}
