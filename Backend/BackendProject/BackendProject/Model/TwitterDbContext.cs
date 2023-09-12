using Microsoft.EntityFrameworkCore;

namespace BackendProject.Model
{
    public class TwitterDbContext : DbContext
    {
        public TwitterDbContext (DbContextOptions options
            ) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<TweetLike> TweetsLike { get; set;}


    }
}
