using System.ComponentModel.DataAnnotations;

namespace JWTAuth.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Username Required")]
        public string Username { get; set; } =string.Empty;

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; } = string.Empty;
    }
}
