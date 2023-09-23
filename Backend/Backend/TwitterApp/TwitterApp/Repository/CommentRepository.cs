using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace TwitterApp.Repository
{
    public class CommentRepository : IComment
    {
        private readonly TwitterDbContext _context;
        private readonly DbSet<Comment> _collection;

        public CommentRepository(TwitterDbContext context)
        {
            _context = context;
            _collection = _context.Comments;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id==comment.User.Id);
            var existingTweet = await _context.Tweets.FirstOrDefaultAsync(t => t.Id == comment.Tweet.Id);
  

            if (user != null && existingTweet!=null) {
                var NewComment = new Comment
                {
                    CommentText = comment.CommentText,
                    CreatedTime = DateTime.Now,
                    TweetId = existingTweet.Id,
                    UserId = user.Id
                    

                };
                await _collection.AddAsync(NewComment);
                await _context.SaveChangesAsync();
                return NewComment;
            }
            return null;
            
        }

        public async Task<bool> DeleteComment(Comment comment)
        {
            _collection.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsByTweetId(int id)
        {
            return await _collection.AsNoTracking().Where(comments => comments.Tweet.Id == id).ToListAsync();
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _collection.AsNoTracking().FirstOrDefaultAsync(comment => comment.Id == id);
        }

        

        public async Task<Comment> UpdateComment(Comment comment)
        {
            _context.Comments.Entry(comment).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return comment;
        }
    }
}
