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
    public class LearnersController : Controller
    {
        private readonly MilestoneContext _context;

        public LearnersController(MilestoneContext context)
        {
            _context = context;
        }

        // GET: Learners
        public async Task<IActionResult> Index()
        {
            var milestoneContext = _context.Learners.Include(l => l.Course).Include(l => l.Leaderboard);
            return View(await milestoneContext.ToListAsync());
        }

        // GET: Learners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Course)
                .Include(l => l.Leaderboard)
                .FirstOrDefaultAsync(m => m.LearnerId == id);
            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // GET: Learners/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["BoardId"] = new SelectList(_context.Leaderboards, "BoardId", "BoardId");
            return View();
        }

        // POST: Learners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearnerId,LearnerName,LearnerGender,CountryOfOrigin,ExperienceLevel,LearnerAge,LearnerBirthdayDate,CourseId,BoardId")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", learner.CourseId);
            ViewData["BoardId"] = new SelectList(_context.Leaderboards, "BoardId", "BoardId", learner.BoardId);
            return View(learner);
        }

        // GET: Learners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", learner.CourseId);
            ViewData["BoardId"] = new SelectList(_context.Leaderboards, "BoardId", "BoardId", learner.BoardId);
            return View(learner);
        }

        // POST: Learners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LearnerId,LearnerName,LearnerGender,CountryOfOrigin,ExperienceLevel,LearnerAge,LearnerBirthdayDate,CourseId,BoardId")] Learner learner)
        {
            if (id != learner.LearnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", learner.CourseId);
            ViewData["BoardId"] = new SelectList(_context.Leaderboards, "BoardId", "BoardId", learner.BoardId);
            return View(learner);
        }

        // GET: Learners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Course)
                .Include(l => l.Leaderboard)
                .FirstOrDefaultAsync(m => m.LearnerId == id);
            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // POST: Learners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learner = await _context.Learners.FindAsync(id);
            if (learner != null)
            {
                _context.Learners.Remove(learner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnerExists(int id)
        {
            return _context.Learners.Any(e => e.LearnerId == id);
        }

        // GET: Learners/JoinQuest
        public async Task<IActionResult> JoinQuest()
        {
            var quests = await _context.CollaborativeQuests.Include(cq => cq.Quest).ToListAsync();
            return View(quests);
        }

        // POST: Learners/JoinQuest/5
        //[HttpPost]
        // [ValidateAntiForgeryToken]
        /* public async Task<IActionResult> JoinQuest(int learnerId, int questId)
         {
             var quest = await _context.CollaborativeQuests.FindAsync(questId);
             if (quest == null || quest.MaxParticipants.HasValue && quest.MaxParticipants <= _context.Learners.Count(l => l.LearnerQuests == questId))
             {
                 return BadRequest("Cannot join quest.");
             }

             var learner = await _context.Learners.FindAsync(learnerId);
             if (learner == null)
             {
                 return NotFound();
             }

             learner.LearnerQuests = questId;
             await _context.SaveChangesAsync();

             return RedirectToAction(nameof(Index));
         }*/
        //}
    }
}
