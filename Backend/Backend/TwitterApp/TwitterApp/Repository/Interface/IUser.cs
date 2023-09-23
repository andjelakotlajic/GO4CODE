using TwitterApp.Model;

namespace TwitterApp.Repository.Interface
{
    public interface IUser
    {
       public Task< User> CreateUser(User user);

      public Task<bool> UpdateUser(User user);

      public Task<User> GetUserByUsername(string username);

       public Task< int> GetUserId(string username);

    public Task<string> GetUserName(int userId);


       public Task DeleteUser(string username);

        void FollowUser(User userToFollow);

        void UnfollowUser(User userToUnfollow);

       public Task<IEnumerable<Tweet>> GetTweets(int id);

        IEnumerable<Tweet> GetFavoriteTweets();

        IEnumerable<User> GetFollowers();

        IEnumerable<User> GetFollowing();
    }
}
