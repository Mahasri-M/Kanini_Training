using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SocialMedia.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // Other user properties

        public ICollection<Post> Posts { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
