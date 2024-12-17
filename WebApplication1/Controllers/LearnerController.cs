using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class LearnerController : Controller
{
    private readonly MilestoneContext _context;
    private readonly UserManager<UserAcccount> _userManager;

    public LearnerController(MilestoneContext context, UserManager<UserAcccount> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Display learner profile
    public async Task<IActionResult> LearnerProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var learner = await _context.Learners
            .Include(l => l.CourseEnrollments) // Include the enrolled courses
            .FirstOrDefaultAsync(l => l.UserId == user.Id);

        if (learner != null)
        {
            var model = new LearnerProfileViewModel
            {
                Fullname = learner.LearnerName,
                EnrolledCourses = learner.CourseEnrollments
            };

            return View(model);
        }

        return NotFound("No learner found.");
    }

    // View all available courses to enroll in
    public async Task<IActionResult> ViewCourses()
    {
        var courses = await _context.Courses.ToListAsync();
        return View(courses);
    }

    // Enroll in a course
    public async Task<IActionResult> EnrollInCourse(int courseId)
    {
        var user = await _userManager.GetUserAsync(User);
        var learner = await _context.Learners.FirstOrDefaultAsync(l => l.UserId == user.Id);

        if (learner == null)
        {
            return NotFound("Learner not found");
        }

        var course = await _context.Courses.FindAsync(courseId);
        if (course == null)
        {
            return NotFound("Course not found");
        }

        // Create a new CourseEnrollment instead of directly adding a Course
        var enrollment = new CourseEnrollment
        {
            LearnerId = learner.LearnerId,
            CourseId = course.CourseId,
            Learner = learner,
            Course = course
        };

        _context.CourseEnrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return RedirectToAction("LearnerProfile"); // Redirect back to learner profile
    }

    // View courses the learner is enrolled in
    public async Task<IActionResult> MyCourses()
    {
        var user = await _userManager.GetUserAsync(User);
        var learner = await _context.Learners
            .Include(l => l.CourseEnrollments) // Include the enrolled courses
            .FirstOrDefaultAsync(l => l.UserId == user.Id);

        if (learner != null)
        {
            return View(learner.CourseEnrollments);
        }

        return NotFound("No learner found.");
    }
}
