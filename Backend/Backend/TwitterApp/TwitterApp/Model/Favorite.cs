namespace TwitterApp.Model
{
    public class Favorite
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Tweet_id { get; set; }
        public Favorite() { }
    }
}
