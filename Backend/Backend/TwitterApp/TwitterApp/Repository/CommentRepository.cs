using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;

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
            var NewComment = new Comment
            {

            CreatedTime = DateTime.Now,
            User = comment.User,
            TweetId = comment.TweetId,
            CommentText = comment.CommentText

        };
            await _collection.AddAsync(NewComment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteComment(Comment comment)
        {
            _collection.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
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
