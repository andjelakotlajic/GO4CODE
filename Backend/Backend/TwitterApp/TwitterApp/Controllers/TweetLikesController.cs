using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterApp.Dto.Likes;
using TwitterApp.Model;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TweetLikesController : ControllerBase
    {
        private readonly ITweetLikeService _tweetLikeService;

        public TweetLikesController(ITweetLikeService tweetLikeService)
        {
            _tweetLikeService = tweetLikeService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateTweetLike(TweetLikeDto tweetLike)
        {
            var result = await _tweetLikeService.LikeTweet(tweetLike);
            return result;
        }



    }
}
