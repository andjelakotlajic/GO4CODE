using AutoMapper;
using TwitterApp.Dto.CommentD;
using TwitterApp.Repository.Interface;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Service
{
    public class CommentService : ICommentService
    {

        private readonly IComment _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(IComment commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateComment(CommentDto comment)
        {
            var _comment = _mapper.Map<Model.Comment>(comment);
            var result = _commentRepository.CreateComment(_comment);
            return _mapper.Map<CommentDto>(result);
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
