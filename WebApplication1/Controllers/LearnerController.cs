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
            Console.WriteLine("User not found in LearnerProfile.");
            return NotFound("User not found");
        }

        // Get the learner associated with the user
        var learner = await _context.Learners
            .FirstOrDefaultAsync(l => l.UserId == user.Id);

        if (learner == null)
        {
            Console.WriteLine("No learner found for user.");
            return NotFound("No learner found.");
        }

        // Fetch course enrollments for the learner
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Course) // Include course details
            .Where(ce => ce.LearnerId == learner.LearnerId) // Match LearnerId
            .ToListAsync();

        // Fetch learning goals for the learner
        var learningGoals = await _context.LearningGoals
            .Where(lg => lg.LearnerId == learner.LearnerId)
            .ToListAsync();

        // Fetch learning paths for the learner
        var learningPaths = await _context.LearningPaths
            .Where(lp => lp.LearnerId == learner.LearnerId)
            .ToListAsync();

        // Prepare the view model
        var model = new LearnerProfileViewModel
        {
            Fullname = learner.LearnerName,
            EnrolledCourses = enrollments, // Pass the matched enrollments
            LearningGoals = learningGoals, // Pass the learning goals
            LearningPaths = learningPaths, // Pass the learning paths
            LearningPathProgresses = new List<LearningPathProgressViewModel>(), // Add your learning path progresses logic here if needed
            DiscussionForumPosts = new List<PostViewModel>() // Add your discussion forum posts logic here if needed
        };

        Console.WriteLine("Returning LearnerProfile view.");
        return View(model);
    }

    // Display complete learner profile information
    // Display complete learner profile information
    public async Task<IActionResult> CompleteProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            Console.WriteLine("User not found in CompleteProfile.");
            return NotFound("User not found");
        }

        // Get the learner associated with the user
        var learner = await _context.Learners
            .FirstOrDefaultAsync(l => l.UserId == user.Id);

        if (learner == null)
        {
            Console.WriteLine("No learner found for user.");
            return NotFound("No learner found.");
        }

        // Fetch course enrollments for the learner
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Course) // Include course details
            .Where(ce => ce.LearnerId == learner.LearnerId) // Match LearnerId
            .ToListAsync();

        // Prepare the view model with available profile information
        var model = new CompleteProfileViewModel
        {
            Fullname = learner.LearnerName,
            Email = user.Email, // Add email to the profile information
            Birthday = learner.LearnerBirthdayDate, // Add birthday to the profile information
            Gender = learner.LearnerGender, // Add gender to the profile information
            PhoneNumber = user.PhoneNumber, // Add phone number to the profile information
            PhoneNumber2 = user.PhoneNumber2,
            EnrolledCourses = enrollments, // Pass the matched enrollments
            CountryOfOrigin = user.CountryOfOrigin,
            ExperienceLevel = user.ExperienceLevel,
            AccountType = user.AccountType,
        };

        Console.WriteLine("Returning CompleteProfile view with complete profile information.");
        return View(model);
    }

    /*public LearnerController(UserManager<UserAcccount> userManager, MilestoneContext context)
     {
         _userManager = userManager;
         _context = context;
     }

     public async Task<IActionResult> LearnerDiscussionForums()
     {
         var user = await _userManager.GetUserAsync(User);
         if (user == null)
         {
             return NotFound("User not found");
         }

         var learner = await _context.Learners
             .FirstOrDefaultAsync(l => l.UserId == user.Id);
         if (learner == null)
         {
             return NotFound("Learner not found");
         }

         var forums = await _context.DiscussionForums
             .Include(f => f.Posts)
             .ToListAsync();
 /*
         var model = new LearnerDiscussionForumViewModel
         {
             LearnerId = learner.LearnerId,
             Forums = forums
         };

         return View(model);
     }
 */

    // Display form to update learner information
    [HttpGet]
    public async Task<IActionResult> UpdateProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            Console.WriteLine("User not found in UpdateProfile.");
            return NotFound("User not found");
        }

        var learner = await _context.Learners.FirstOrDefaultAsync(l => l.UserId == user.Id);
        if (learner == null)
        {
            Console.WriteLine("No learner found for user.");
            return NotFound("No learner found.");
        }

        var model = new UpdateProfileViewModel
        {
            Fullname = learner.LearnerName,
            Email = user.Email,
            Birthday = learner.LearnerBirthdayDate,
            Gender = learner.LearnerGender,
            //PhoneNumber = learner.LearnerPhoneNumber,
            // PhoneNumber2 = learner.LearnerPhoneNumber2,
            CountryOfOrigin = learner.CountryOfOrigin
        };

        return View(model);
    }

    // Handle form submission to update learner information
    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Console.WriteLine("User not found in UpdateProfile.");
                return NotFound("User not found");
            }

            var learner = await _context.Learners.FirstOrDefaultAsync(l => l.UserId == user.Id);
            if (learner == null)
            {
                Console.WriteLine("No learner found for user.");
                return NotFound("No learner found.");
            }

            // Update learner information
            learner.LearnerName = model.Fullname;
            learner.LearnerBirthdayDate = model.Birthday;
            learner.LearnerGender = model.Gender;
            //   learner.LearnerPhoneNumber = model.PhoneNumber;
            //   learner.LearnerPhoneNumber2 = model.PhoneNumber2;
            learner.CountryOfOrigin = model.CountryOfOrigin;

            _context.Learners.Update(learner);

            // Update user information
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Fullname = model.Fullname;

            user.PhoneNumber = model.PhoneNumber;

            var userUpdateResult = await _userManager.UpdateAsync(user);
            if (!userUpdateResult.Succeeded)
            {
                // Handle errors here
                foreach (var error in userUpdateResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            await _context.SaveChangesAsync();

            // Redirect to the complete profile view after successful update
            return RedirectToAction("CompleteProfile");
        }

        // If model state is not valid, return the view with the model to show validation errors
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
    [HttpGet]
    public IActionResult AddLearningGoal()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> LearningPathProgress(int pathId)
    {
        var learningPath = await _context.LearningPaths
            .FirstOrDefaultAsync(lp => lp.PathId == pathId);

        if (learningPath == null)
        {
            return NotFound("Learning Path not found");
        }

        var model = new LearningPathProgressViewModel
        {
            PathDescription = learningPath.PathDescription,
            LearnerStatus = learningPath.LearnerStatus,
            StartDate = DateTime.Now, // Replace with actual data if available
            EndDate = DateTime.Now.AddMonths(3), // Replace with actual data if available
            ProgressPercentage = 50 // Replace with actual calculation if available
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddLearningGoal(LearningGoal model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Console.WriteLine("User not found in AddLearningGoal.");
                return NotFound("User not found");
            }

            var learner = await _context.Learners.FirstOrDefaultAsync(l => l.UserId == user.Id);
            if (learner == null)
            {
                Console.WriteLine("No learner found for user.");
                return NotFound("No learner found.");
            }

            model.LearnerId = learner.LearnerId;
            _context.LearningGoals.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("LearnerProfile");
        }

        return View(model);
    }

}
