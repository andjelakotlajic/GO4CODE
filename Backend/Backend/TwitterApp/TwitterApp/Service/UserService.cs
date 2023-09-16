using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public User CreateUser(UserDtoAdd user)
        {
            var _user = _mapper.Map<Model.User>(user);
            return _userRepository.CreateUser(_user);
            
        }
        public UserDto GetUserByUsername(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
                return _mapper.Map<UserDto>(user);

        }

        public void DeleteUser(string username)
        {
            _userRepository.DeleteUser(username);
        }



        public bool UpdateUser(UserDtoPut user)
        {
            var _user = _mapper.Map<Model.User>(user);
            _userRepository.UpdateUser(_user);
            return true;
        }
    }
}
