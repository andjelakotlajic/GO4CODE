using AutoMapper;
using TwitterApp.Dto.Likes;
using TwitterApp.Model;
using TwitterApp.Repository;
using TwitterApp.Repository.Interface;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Service
{

        public class TweetLikeService : ITweetLikeService
        {
            private readonly IMapper _mapper;
        private readonly ITweetLike _tweetLikeRepository;


            public TweetLikeService(IMapper mapper,ITweetLike tweetLikeRepository)
            {

                _mapper = mapper;

            _tweetLikeRepository = tweetLikeRepository;
            }


            public async Task<bool> LikeTweet(TweetLikeDto tweetLike)
            {
            var tweet =  _mapper.Map<TweetLike>(tweetLike);
            var result = await _tweetLikeRepository.LikeTweet(tweet);
            return result;
                
             }
        }
    }
