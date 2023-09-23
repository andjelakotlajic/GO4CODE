using AutoMapper;
using TwitterApp.Dto.CommentD;
using TwitterApp.Repository.Interface;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Service
{
    public class CommentService : ICommentService
    {

        private readonly IComment _commentRepository;
        private readonly ITweet _tweetRepository;
        private readonly IUser _userRepository;
        private readonly IMapper _mapper;

        public CommentService(IComment commentRepository, IMapper mapper,ITweet tweet,IUser user)
        {
            _commentRepository = commentRepository;
            _tweetRepository = tweet;
            _userRepository = user;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateComment(CommentDto comment,int tweetId)
        {
            var tweet = await _tweetRepository.Get(tweetId);
            var user = await  _userRepository.GetUserByUsername(await _userRepository.GetUserName(comment.UserId));

            if (tweet!=null && user!=null)
            {
                
                var _comment = _mapper.Map<Model.Comment>(comment);
                _comment.Tweet =await _tweetRepository.Get(tweetId);
                _comment.User = user;
                var result = await _commentRepository.CreateComment(_comment);
                return _mapper.Map<CommentDto>(result);
            }
            return null;
           
        }

        public async Task<bool> DeleteComment(int id)
        {
            var exists = await _commentRepository.GetComment(id);
            if(exists != null)
            {
                await _commentRepository.DeleteComment(exists);
                return true;
            }
            return false;
        }

        public async Task<CommentDto> UpdateComment(CommentDto comment)
        {
            var _comment = _mapper.Map<Model.Comment>(comment);

            await _commentRepository.UpdateComment(_comment);
            return _mapper.Map<CommentDto>(_comment);
        }
    }
}
