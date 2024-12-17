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

        // Get the learner associated with the user
        var learner = await _context.Learners
            .FirstOrDefaultAsync(l => l.UserId == user.Id);

        if (learner == null)
        {
            return NotFound("No learner found.");
        }

        // Fetch course enrollments for the learner
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Course) // Include course details
            .Where(ce => ce.LearnerId == learner.LearnerId) // Match LearnerId
            .ToListAsync();

        // Prepare the view model
        var model = new LearnerProfileViewModel
        {
            Fullname = learner.LearnerName,
            EnrolledCourses = enrollments // Pass the matched enrollments
        };

        return View(model);
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
        // Get the currently logged-in user
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound("User not found");
        }

        // Fetch the learner associated with this user
        var learner = await _context.Learners
            .FirstOrDefaultAsync(l => l.UserId == user.Id);

        if (learner == null)
        {
            return NotFound("Learner not found");
        }

        // Fetch the courses the learner is enrolled in from CourseEnrollment
        var enrolledCourses = await _context.CourseEnrollments
            .Include(ce => ce.Course) // Include course details
            .Where(ce => ce.LearnerId == learner.LearnerId) // Filter by Learner ID
            .Select(ce => ce.Course) // Select the course details
            .ToListAsync();

        return View(enrolledCourses); // Pass the list of courses to the view
    }

}
