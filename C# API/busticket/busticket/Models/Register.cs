using System.ComponentModel.DataAnnotations;

namespace busticket.Models
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
