using TwitterApp.Dto;
using TwitterApp.Dto.UserD;
using TwitterApp.Model;

namespace TwitterApp.Service.ServiceInterface
{
    public interface IUserService
    {
       
          public Task<User> CreateUser(UserDtoAdd user);
          public Task<User> CreateUser(RegisterUserRequest user);
        public Task<UserDto> GetUserByUsername(string username);
           public Task DeleteUser(string username);
           public Task<bool> UpdateUser(UserDtoPut user);
        public Task<int> GetUserId(string username);


    }
}
