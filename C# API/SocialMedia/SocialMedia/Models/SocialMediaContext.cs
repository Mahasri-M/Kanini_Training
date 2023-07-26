using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace SocialMedia.Models
{
    public class SocialMediaContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {

        }
      


    }

}
