using WebApplication1.Models;

public class LearnerProfileViewModel
{
    public string Fullname { get; set; }
    public List<CourseEnrollment> EnrolledCourses { get; set; }
    public List<LearningGoal> LearningGoals { get; set; }
    public List<LearningPath> LearningPaths { get; set; } // Add this property
    public List<LearningPathProgressViewModel> LearningPathProgresses { get; set; }
    public List<PostViewModel> DiscussionForumPosts { get; set; }
}
