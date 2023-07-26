using busticket.Models;
using Microsoft.EntityFrameworkCore;

namespace busticket.Services.UserRepo
{
    public class User_service:IUser
    {
        private readonly BusContext _UserContext;
        public User_service(BusContext context)
        {
            _UserContext = context;
        }
        //GetAllUsers
        public IEnumerable<User> GetAllUsers()
        {
            return _UserContext.Users.ToList();
        }
        //GetUserById
        public User GetUserById(int User_Id)
        {
            return _UserContext.Users.FirstOrDefault(x => x.UserId == User_Id);
        }
        //PostUser
        public async Task<List<User>> AddUserDetails(User user)
        {
            _UserContext.Users.Add(user);
            await _UserContext.SaveChangesAsync();

            return await _UserContext.Users.ToListAsync();
        }
        //Put
        public async Task<List<User>?> UpdateUserDetailsById(int id, User user)
        {
            var users = await _UserContext.Users.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            users.Name = user.Name;
            users.Email = user.Email;
            users.Mobile = user.Mobile;
            users.Pwd = user.Pwd;

            await _UserContext.SaveChangesAsync();
            return await _UserContext.Users.ToListAsync();
        }
        //Delete
        public async Task<List<User>?> DeleteUserDetailsById(int id)
        {
            var users = await _UserContext.Users.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            _UserContext.Remove(users);
            await _UserContext.SaveChangesAsync();
            return await _UserContext.Users.ToListAsync();
        }
    }

}
