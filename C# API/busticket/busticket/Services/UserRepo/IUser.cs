using busticket.Models;

namespace busticket.Services.UserRepo
{
    public interface IUser
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int User_Id);
        Task<List<User>> AddUserDetails(User user);
        Task<List<User>?> UpdateUserDetailsById(int id, User user);
        Task<List<User>?> DeleteUserDetailsById(int id);
    }
}
