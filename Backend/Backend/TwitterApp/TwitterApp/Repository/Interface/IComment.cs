using TwitterApp.Model;

namespace TwitterApp.Repository.Interface
{
    public interface IComment
    {
        public Task<Comment> CreateComment(Comment comment);
        public Task<Comment> UpdateComment(Comment comment);

        public Task<bool> DeleteComment(Comment comment);

        public Task<Comment> GetComment(int id);

    }
}
