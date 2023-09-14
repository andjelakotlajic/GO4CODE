﻿using TwitterApp.Dto.TweetD;
using TwitterApp.Model;

namespace TwitterApp.Service.ServiceInterface
{
    public interface ITweetService
    {
       public  Task<TweetPut> CreateTweet(TweetPut tweet);
       public Task<bool> UpdateTweet(TweetPut tweet);

        public Task<bool>  DeleteTweet (int id);

       public Task<IEnumerable<TweetPut>> GetTweets();
    }
}
