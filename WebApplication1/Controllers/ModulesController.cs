using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ModulesController : Controller
    {
        private readonly MilestoneContext _context;
        private readonly UserManager<UserAcccount> _userManager;

        public ModulesController(MilestoneContext context, UserManager<UserAcccount> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
            var modules = _context.Modules.Include(m => m.Course);
            return View(await modules.ToListAsync());
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.Modules
                .Include(m => m.Course)
                .FirstOrDefaultAsync(m => m.ModuleId == id);

            if (module == null)
            {
                return NotFound();
            }

            return View(module);
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            ViewData["Course_ID"] = new SelectList(_context.Courses, "Course_ID", "Course_Title");
            ViewBag.ModuleId = new SelectList(_context.Modules, "ModuleId", "ModuleTitle");

            // If there is a Log model (you can adjust this if not needed)
            ViewBag.LogId = new SelectList(_context.InteractionLogs, "LogId", "LogTitle"); // Adjust this as needed

            // Pass the available Courses to the dropdown
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseId");
            return View();
        }

        // POST: Modules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Module_ID,Module_Title,Course_ID")] Module module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Course_ID"] = new SelectList(_context.Courses, "Course_ID", "Course_Title", module.CourseId);
            return View(module);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            // Ensure the current user is an instructor (no course relation check)
            var user = await _userManager.GetUserAsync(User);
            var isInstructor = await _context.Instructors
                .AnyAsync(i => i.UserId == user.Id);

            if (!isInstructor)
            {
                return Unauthorized(); // Only instructors can edit
            }

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseTitle", module.CourseId);
            return View(module);
        }

        // POST: Modules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModuleId,ModuleTitle,CourseId")] Module module)
        {
            if (id != module.ModuleId)
            {
                return NotFound();
            }

            // Ensure the current user is an instructor (no course relation check)
            var user = await _userManager.GetUserAsync(User);
            var isInstructor = await _context.Instructors
                .AnyAsync(i => i.UserId == user.Id);

            if (!isInstructor)
            {
                return Unauthorized(); // Only instructors can edit
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(module.ModuleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseTitle", module.CourseId);
            return View(module);
        }

        // GET: Modules/AddActivity/5
        public IActionResult AddActivity(int moduleId)
        {
            // Ensure the current user is an instructor for this module's course
            var user = _userManager.GetUserAsync(User).Result;
            var isInstructor = _context.Instructors
                .Any(i => i.UserId == user.Id);

            if (!isInstructor)
            {
                return Unauthorized(); // Only instructors can add activities
            }

            ViewBag.ModuleId = moduleId;  // Pass moduleId to the view
            return View();  // It will automatically look in Views/Modules/LearningActivities
        }

        // POST: Modules/AddActivity/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddActivity(int moduleId, [Bind("ActivityType,DetailedInstructions,MaxPoints")] LearningActivity activity)
        {
            var user = await _userManager.GetUserAsync(User);
            var isInstructor = await _context.Instructors
                .AnyAsync(i => i.UserId == user.Id);

            if (!isInstructor)
            {
                return Unauthorized(); // Only instructors can add activities
            }

            if (ModelState.IsValid)
            {
                activity.ModuleId = moduleId; // Associate the activity with the module
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = moduleId }); // Redirect to module details page
            }
            return View();  // It will automatically look in Views/Modules/LearningActivities
        }


        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.Modules
                .Include(m => m.Course)
                .FirstOrDefaultAsync(m => m.ModuleId == id);

            if (module == null)
            {
                return NotFound();
            }

            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module != null)
            {
                _context.Modules.Remove(module);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
       

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.ModuleId == id);
        }
    }
}
