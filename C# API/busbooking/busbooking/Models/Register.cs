using System.ComponentModel.DataAnnotations;

namespace busbooking.Models
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
