using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Comment
    {
        [Key]
        public int ?Id { get; set; }
        public string ?Content { get; set; }
        // Other comment properties

      
        public User ?Users { get; set; }

      
        public Post ?Posts { get; set; }
    }
}
