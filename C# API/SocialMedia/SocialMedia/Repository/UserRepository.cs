using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Repository
{
    
    public class UserRepository : IUsers
    {
        private readonly SocialMediaContext _dbContext;

        public UserRepository(SocialMediaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void CreateUser(User user)
        {
           
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            

        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }

}
