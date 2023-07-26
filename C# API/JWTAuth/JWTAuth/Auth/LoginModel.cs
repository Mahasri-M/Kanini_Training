using System.ComponentModel.DataAnnotations;

namespace JWTAuth.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string? Username { get; set; } 

        [Required(ErrorMessage = "Password Required")]
        public string? Password { get; set; } 
    }
}
