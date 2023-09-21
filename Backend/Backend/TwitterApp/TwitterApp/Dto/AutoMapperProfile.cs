﻿using AutoMapper;
using TwitterApp.Dto.CommentD;
using TwitterApp.Dto.TweetD;
using TwitterApp.Dto.UserD;
using TwitterApp.Model;

namespace TwitterApp.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDtoAdd>().ReverseMap();
            CreateMap<User, UserDtoPut>().ReverseMap();
            CreateMap<Tweet, TweetPut>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Tweet,TweetResponse>().ReverseMap();
        }
    }
}