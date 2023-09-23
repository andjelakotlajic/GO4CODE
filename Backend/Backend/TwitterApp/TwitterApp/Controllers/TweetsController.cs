using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterApp.Dto.TweetD;
using TwitterApp.Model;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {

            _tweetService = tweetService;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TweetsRequest>>> GetTweets([FromQuery] string search)
        {
            var result = await _tweetService.GetTweetsSearch(search);
            return Ok(result);
        }
        [HttpGet("byUserId/{userid}")]
        public async Task<ActionResult<IEnumerable<TweetsResponse>>> GetTweets(int userid)
        {
            var result = await _tweetService.GetTweets(userid);
            return Ok(result);
        }




        [HttpPost]
        public async Task<ActionResult<TweetsRequest>> CreateTweet(TweetsRequest tweet)
        {
            var result = await _tweetService.CreateTweet(tweet);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTweet(int id)
        {
            var result = await _tweetService.DeleteTweet(id);
            return result == false ? NotFound() : Ok(result);
        }

       



    }
}
