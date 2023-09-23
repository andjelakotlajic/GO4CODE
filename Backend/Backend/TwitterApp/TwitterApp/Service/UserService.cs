using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwitterApp.Dto;
using TwitterApp.Dto.UserD;
using TwitterApp.Model;
using TwitterApp.Repository.Interface;
using TwitterApp.Service.ServiceInterface;

namespace TwitterApp.Service
{
    public class UserService : IUserService
    {
        private readonly IUser _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUser userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(UserDtoAdd user)
        {
            var _user = _mapper.Map<Model.User>(user);
            return await _userRepository.CreateUser(_user);
            
        }
        public async Task<User> CreateUser(RegisterUserRequest user)
        {
            var _user = _mapper.Map<Model.User>(user);
            return await _userRepository.CreateUser(_user);

        }
        public async Task<UserDto> GetUserByUsername(string username)
        {

            var user = await _userRepository.GetUserByUsername(username);
            return  _mapper.Map<UserDto>(user);

        }

        public async Task DeleteUser(string username)
        {
            await _userRepository.DeleteUser(username);
        }



        public async Task<bool> UpdateUser(UserDtoPut user)
        {
            var _user = _mapper.Map<Model.User>(user);
            await   _userRepository.UpdateUser(_user);
            return true;
        }


    }
}
