using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public enum ExperienceLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3,
    }

    public enum AccountType
    {
        Learner=1,
        Admin=2,
        Instructor=3
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
        [Required(ErrorMessage = "Phonee number is required")]
        public int PhoneNumber { get; set; }

        public int PhoneNumber2 { get; set; }
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
