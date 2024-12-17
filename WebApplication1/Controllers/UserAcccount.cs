using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserAcccount : IdentityUser
    {
        [Required(ErrorMessage = "FullName is Required")]
        public string Fullname { get; set; }
        //public string Password { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }

        public AccountType AccountType { get; set; }
    }
}
