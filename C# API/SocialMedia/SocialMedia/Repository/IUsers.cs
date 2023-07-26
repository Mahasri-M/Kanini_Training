using SocialMedia.Models;

namespace SocialMedia.Repository
{
    public interface IUsers
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
