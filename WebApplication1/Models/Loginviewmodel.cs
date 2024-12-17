using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Loginviewmodel
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
