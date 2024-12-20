using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

public class InstructorController : Controller
{
    private readonly UserManager<UserAcccount> _userManager;
    private readonly MilestoneContext _context;

    public InstructorController(UserManager<UserAcccount> userManager, MilestoneContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IActionResult> InstructorDashboard()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var instructor = await _context.Instructors
            .Include(i => i.Emails)
            .FirstOrDefaultAsync(i => i.UserId == user.Id);

        if (instructor == null)
        {
            return NotFound("Instructor not found");
        }

        var model = new InstructorProfileViewModel
        {
            InstructorId = instructor.InstructorId,
            Name = instructor.InstructorName,
            ExpertiseAreas = instructor.ExpertiseAreas,
            Qualifications = instructor.Qualifications,
            Emails = instructor.Emails.Select(e => e.Email).ToList()
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var instructor = await _context.Instructors
            .Include(i => i.Emails)
            .FirstOrDefaultAsync(i => i.UserId == user.Id);

        if (instructor == null)
        {
            return NotFound("Instructor not found");
        }

        var model = new InstructorProfileViewModel
        {
            InstructorId = instructor.InstructorId,
            Name = instructor.InstructorName,
            ExpertiseAreas = instructor.ExpertiseAreas,
            Qualifications = instructor.Qualifications,
            Emails = instructor.Emails.Select(e => e.Email).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(InstructorProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var instructor = await _context.Instructors
                .Include(i => i.Emails)
                .FirstOrDefaultAsync(i => i.UserId == user.Id);

            if (instructor == null)
            {
                return NotFound("Instructor not found");
            }

            instructor.InstructorName = model.Name;
            instructor.ExpertiseAreas = model.ExpertiseAreas;
            instructor.Qualifications = model.Qualifications;

            // Update emails
            instructor.Emails.Clear();
            foreach (var email in model.Emails)
            {
                instructor.Emails.Add(new InstructorEmail { Email = email });
            }

            _context.Update(instructor);
            await _context.SaveChangesAsync();

            return RedirectToAction("InstructorDashboard");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult CreateLearningPath()
    {
        return View();
    }

    [HttpPost]

    public async Task<IActionResult> CreateLearningPath(LearningPathViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.UserId == user.Id);
        if (instructor == null)
        {
            return NotFound("Instructor not found");
        }

        if (ModelState.IsValid)
        {

            var learningPath = new LearningPath
            {
                Rules = model.Rules,
                LearnerStatus = model.LearnerStatus,
                PathDescription = model.PathDescription,
                InstructorId = instructor.InstructorId,
                LearnerId = model.LearnerId
            };


            _context.LearningPaths.Add(learningPath);
            await _context.SaveChangesAsync();

            return RedirectToAction("InstructorDashboard");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult CreateForum()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateForum(DiscussionForum model)
    {
        if (ModelState.IsValid)
        {
            _context.DiscussionForums.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("InstructorDashboard");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> AddPost(int forumId)
    {
        var forum = await _context.DiscussionForums.FindAsync(forumId);
        if (forum == null)
        {
            return NotFound("Forum not found");
        }
        var model = new Post { ForumId = forumId };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddPost(Post model)
    {
        if (ModelState.IsValid)
        {
            model.CreatedAt = DateTime.Now;
            _context.Posts.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewForum", new { id = model.ForumId });
        }
        return View(model);
    }

    public async Task<IActionResult> ViewForum(int id)
    {
        var forum = await _context.DiscussionForums
            .Include(f => f.Posts)
            .FirstOrDefaultAsync(f => f.ForumId == id);

        if (forum == null)
        {
            return NotFound("Forum not found");
        }
        return View(forum);
    }


    public async Task<IActionResult> ViewLearningPaths()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found");
        }

        var instructor = await _context.Instructors
            .FirstOrDefaultAsync(i => i.UserId == user.Id);

        if (instructor == null)
        {
            return NotFound("Instructor not found");
        }

        var learningPaths = await _context.LearningPaths
            .Where(lp => lp.InstructorId == instructor.InstructorId)
            .ToListAsync();

        return View(learningPaths);
    }
}
