using AutoMapper;
using System.Collections.Generic;
using TwitterApp.Dto.TweetD;
using TwitterApp.Model;
using TwitterApp.Repository;
using TwitterApp.Repository.Interface;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Service
{
    public class TweetService : ITweetService
    {
        private readonly ITweet _tweetRepository;
        private readonly IUser _userRepository;
        private readonly IMapper _mapper;

        public TweetService(ITweet tweetRepository,IMapper mapper,IUser userRepository)
        {
            _tweetRepository = tweetRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task< TweetsRequest> CreateTweet(TweetsRequest tweet)
        {
            var _tweet = _mapper.Map<Tweet>(tweet);
            _tweet.UserId = await _userRepository.GetUserId(tweet.UserName);
            var createdTweet = await _tweetRepository.CreateTweet(_tweet);
            var result = _mapper.Map<TweetsRequest>(createdTweet);
            result.UserName = await _userRepository.GetUserName(_tweet.UserId);
            return result;

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

        public async Task<IEnumerable<TweetsResponse>> GetTweets(int userid)
        {
            var tweets = await _tweetRepository.GetTweets(userid);

            return _mapper.Map<IEnumerable<TweetsResponse>>(tweets);

        }

        public async Task<IEnumerable<TweetsRequest>> GetTweetsSearch(string search)
        {


            var tweets = await _tweetRepository.GetTweetsSearch(search);
            var TweetsRequests = _mapper.Map<IEnumerable<TweetsRequest>>(tweets);
            return TweetsRequests;
        }

        public async Task<bool> UpdateTweet(TweetPut tweet)
        {
            var _tweet = _mapper.Map<Model.Tweet>(tweet);

            await _tweetRepository.UpdateTweet(_tweet);
            return true;
        }


    }
}
