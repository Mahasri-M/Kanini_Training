using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Post
    {
        [Key]
        public int ?Id { get; set; }
        public string ?Title { get; set; }
        public string ?Content { get; set; }
        // Other post properties

   
        public User ?Users { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
