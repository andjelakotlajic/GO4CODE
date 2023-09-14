using AutoMapper;
using TwitterApp.Dto.TweetD;
using TwitterApp.Repository;
using TwitterApp.Repository.Interface;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Service
{
    public class TweetService : ITweetService
    {
        private readonly ITweet _tweetRepository;
        private readonly IMapper _mapper;

        public TweetService(ITweet tweetRepository,IMapper mapper)
        {
            _tweetRepository = tweetRepository;
            _mapper = mapper;
        }
        public async Task< TweetPut> CreateTweet(TweetPut tweet)
        {
            var _tweet = _mapper.Map<Model.Tweet>(tweet);
            var result = _tweetRepository.CreateTweet(_tweet);
            return _mapper.Map<TweetPut>(result);

        }

        public async Task<bool> DeleteTweet(int id)
        {
            var exists = await _tweetRepository.Get(id);
            if(exists != null)
            {
                await _tweetRepository.DeleteTweet(exists);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TweetPut>> GetTweets()
        {
            var tweets = await _tweetRepository.GetTweets();
            return _mapper.Map<IEnumerable<TweetPut>>(tweets);

        }

        public async Task<bool> UpdateTweet(TweetPut tweet)
        {
            var _tweet = _mapper.Map<Model.Tweet>(tweet);

            await _tweetRepository.UpdateTweet(_tweet);
            return true;
        }


    }
}
