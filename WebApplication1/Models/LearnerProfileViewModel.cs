namespace WebApplication1.Models
{
    public class LearnerProfileViewModel
    {
        public string Fullname { get; set; }
        public IEnumerable<CourseEnrollment> EnrolledCourses { get; set; }
    }

}
