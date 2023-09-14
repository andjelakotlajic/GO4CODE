using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace TwitterApp.Model
{
    public class TwitterDbContext : IdentityDbContext<IdentityUser> 
    {
 

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<TweetLike> TweetsLike { get; set; }

        public TwitterDbContext(DbContextOptions<TwitterDbContext> options
    ) : base(options) { }
    }
}
