using TwitterApp.Model;

namespace TwitterApp.Repository.Interface
{
    public interface IUser
    {
        User CreateUser(User user);

        bool UpdateUser(User user);

        User GetUserByUsername(string username);


        void DeleteUser(string username);

        void FollowUser(User userToFollow);

        void UnfollowUser(User userToUnfollow);

        IEnumerable<Tweet> GetTweets();

        IEnumerable<Tweet> GetFavoriteTweets();

        IEnumerable<User> GetFollowers();

        IEnumerable<User> GetFollowing();
    }
}
