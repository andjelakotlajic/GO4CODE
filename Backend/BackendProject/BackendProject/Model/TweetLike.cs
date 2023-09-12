namespace BackendProject.Model
{
    public class TweetLike
    {
        public  int Id { get; set; }
        public int User_id { get; set; }
        public int Tweet_id { get; set; }
        public DateTime Liketime { get; set; }

        public TweetLike() { }
    }
}
