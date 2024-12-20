using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using WebApplication1.Data;
using WebApplication1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

public class DiscussionForumController : Controller
{
    private readonly MilestoneContext _context;
    private readonly UserManager<UserAcccount> _userManager;

    public DiscussionForumController(MilestoneContext context, UserManager<UserAcccount> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> ViewAllForums()
    {
        var forums = await _context.DiscussionForums.ToListAsync();
        return View(forums);
    }

    // Display Forum with Posts
    [HttpGet]
    public async Task<IActionResult> ViewForum(int forumId)
    {
        var forum = await _context.DiscussionForums
            .Include(f => f.Posts)
            .FirstOrDefaultAsync(f => f.ForumId == forumId);

        if (forum == null)
        {
            return NotFound("Forum not found");
        }

        var model = new ForumViewModel
        {
            ForumId = forum.ForumId,
            Title = forum.Title,
            Description = forum.Description,
            Posts = forum.Posts.Select(p => new PostViewModel
            {
                ForumId = p.ForumId ?? 0,
                Content = p.Content ?? string.Empty
            }).ToList()
        };

        return View(model);
    }

    // Display Form to Add Post
    [HttpGet]
    public IActionResult AddPost(int forumId)
    {
        var model = new PostViewModel
        {
            ForumId = forumId
        };

        return View(model);
    }

    // Handle Form Submission to Add Post
    [HttpPost]
    public async Task<IActionResult> AddPost(PostViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var learner = await _context.Learners.FirstOrDefaultAsync(l => l.UserId == user.Id);
            if (learner == null)
            {
                return NotFound("Learner not found");
            }

            var post = new Post
            {
                ForumId = model.ForumId,
                LearnerId = learner.LearnerId,
                Content = model.Content,
                CreatedAt = DateTime.Now
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewForum", new { forumId = model.ForumId });
        }

        return View(model);
    }
}
