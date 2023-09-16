using TwitterApp.Dto.UserD;
using TwitterApp.Model;

namespace TwitterApp.Service.ServiceInterface
{
    public interface IUserService
    {
       
            User CreateUser(UserDtoAdd user);
            UserDto GetUserByUsername(string username);
            void DeleteUser(string username);
            bool UpdateUser(UserDtoPut user);
        
    }
}
