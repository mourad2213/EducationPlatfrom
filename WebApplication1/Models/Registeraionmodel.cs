using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public enum ExperienceLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public enum AccountType
    {
        Learner,
        Admin,
        Instructor
    }

    public class Registeraionmodel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Experience level is required")]
        public ExperienceLevel ExperienceLevel { get; set; }

        [Required(ErrorMessage = "Country of origin is required")]
        public string CountryOfOrigin { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public AccountType AccountType { get; set; }
    }
}
