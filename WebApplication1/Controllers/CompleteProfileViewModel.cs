using WebApplication1.Models;

public class CompleteProfileViewModel
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public DateOnly Birthday { get; set; }
    public string Gender { get; set; }
    public int PhoneNumber { get; set; }
    public int PhoneNumber2 { get; set; }
    public string CountryOfOrigin { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public AccountType AccountType { get; set; }
    public List<CourseEnrollment> EnrolledCourses { get; set; }
}
