using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LearningActivitiesController : Controller
    {
        private readonly MilestoneContext _context;

        public LearningActivitiesController(MilestoneContext context)
        {
            _context = context;
        }

        // GET: LearningActivities
        public async Task<IActionResult> Index()
        {
            var milestoneContext = _context.LearningActivities.Include(l => l.Course).Include(l => l.Log).Include(l => l.Module);
            return View(await milestoneContext.ToListAsync());
        }

        // GET: LearningActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningActivity = await _context.LearningActivities
                .Include(l => l.Course)
                .Include(l => l.Log)
                .Include(l => l.Module)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (learningActivity == null)
            {
                return NotFound();
            }

            return View(learningActivity);
        }

        // GET: LearningActivities/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["LogId"] = new SelectList(_context.InteractionLogs, "LogId", "LogId");
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId");
            return View();
        }

        // POST: LearningActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,ActivityType,DetailedInstructions,MaxPoints,ModuleId,LogId,CourseId")] LearningActivity learningActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", learningActivity.CourseId);
            ViewData["LogId"] = new SelectList(_context.InteractionLogs, "LogId", "LogId", learningActivity.LogId);
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", learningActivity.ModuleId);
            return View(learningActivity);
        }

        // GET: LearningActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningActivity = await _context.LearningActivities.FindAsync(id);
            if (learningActivity == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", learningActivity.CourseId);
            ViewData["LogId"] = new SelectList(_context.InteractionLogs, "LogId", "LogId", learningActivity.LogId);
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", learningActivity.ModuleId);
            return View(learningActivity);
        }

        // POST: LearningActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,ActivityType,DetailedInstructions,MaxPoints,ModuleId,LogId,CourseId")] LearningActivity learningActivity)
        {
            if (id != learningActivity.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningActivityExists(learningActivity.ActivityId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", learningActivity.CourseId);
            ViewData["LogId"] = new SelectList(_context.InteractionLogs, "LogId", "LogId", learningActivity.LogId);
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", learningActivity.ModuleId);
            return View(learningActivity);
        }

        // GET: LearningActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningActivity = await _context.LearningActivities
                .Include(l => l.Course)
                .Include(l => l.Log)
                .Include(l => l.Module)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (learningActivity == null)
            {
                return NotFound();
            }

            return View(learningActivity);
        }

        // POST: LearningActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningActivity = await _context.LearningActivities.FindAsync(id);
            if (learningActivity != null)
            {
                _context.LearningActivities.Remove(learningActivity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningActivityExists(int id)
        {
            return _context.LearningActivities.Any(e => e.ActivityId == id);
        }
    }
}
