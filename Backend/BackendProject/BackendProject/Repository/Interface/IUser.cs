using BackendProject.Dto.UserD;
using BackendProject.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Repository.Interface
{
    public interface IUser

    {
        //Metoda za kreiranje korisnika

        void CreateUser(User user);

        //Metoda za update korisnika

        void UpdateUser(User user);

        User GetUserByUsername(string username);

        void DeleteUser(string username);

        // Metoda za praćenje drugih korisnika
        void FollowUser(User userToFollow);

        // Metoda za prestanak praćenja drugih korisnika
        void UnfollowUser(User userToUnfollow);



        // Metoda za dohvatanje liste tweet-ova korisnika
        IEnumerable<Tweet> GetTweets();

        // Metoda za dohvatanje liste omiljenih tweet-ova korisnika
        IEnumerable<Tweet> GetFavoriteTweets();

        // Metoda za dohvatanje liste pratilaca
        IEnumerable<User> GetFollowers();

        // Metoda za dohvatanje liste korisnika koje trenutni korisnik prati
        IEnumerable<User> GetFollowing();


    }
}
