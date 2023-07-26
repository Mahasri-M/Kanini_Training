using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Group
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        // Other group properties

        public ICollection<User>? Users { get; set; }
    }
}
