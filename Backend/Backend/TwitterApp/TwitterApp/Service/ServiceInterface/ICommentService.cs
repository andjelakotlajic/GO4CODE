using TwitterApp.Dto.CommentD;
using TwitterApp.Model;

namespace TwitterApp.Service.ServiceInterface
{
    public interface ICommentService
    {
        public Task<CommentDto> CreateComment(CommentDto comment);
        public Task<CommentDto> UpdateComment(CommentDto comment);

        public Task<bool> DeleteComment(int id);

       
    }
}
