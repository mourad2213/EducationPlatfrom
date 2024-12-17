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
    public class CollaborativeQuestsController : Controller
    {
        private readonly MilestoneContext _context;

        public CollaborativeQuestsController(MilestoneContext context)
        {
            _context = context;
        }

        // GET: CollaborativeQuests
        public async Task<IActionResult> Index()
        {
            var milestoneContext = _context.CollaborativeQuests.Include(c => c.Quest);
            return View(await milestoneContext.ToListAsync());
        }

        // GET: CollaborativeQuests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborativeQuest = await _context.CollaborativeQuests
                .Include(c => c.Quest)
                .FirstOrDefaultAsync(m => m.QuestId == id);
            if (collaborativeQuest == null)
            {
                return NotFound();
            }

            return View(collaborativeQuest);
        }

        // GET: CollaborativeQuests/Create
        public IActionResult Create()
        {
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId");
            return View();
        }

        // POST: CollaborativeQuests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestId,Deadline,MaxParticipants")] CollaborativeQuest collaborativeQuest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaborativeQuest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId", collaborativeQuest.QuestId);
            return View(collaborativeQuest);
        }

        // GET: CollaborativeQuests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborativeQuest = await _context.CollaborativeQuests.FindAsync(id);
            if (collaborativeQuest == null)
            {
                return NotFound();
            }
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId", collaborativeQuest.QuestId);
            return View(collaborativeQuest);
        }

        // POST: CollaborativeQuests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestId,Deadline,MaxParticipants")] CollaborativeQuest collaborativeQuest)
        {
            if (id != collaborativeQuest.QuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaborativeQuest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaborativeQuestExists(collaborativeQuest.QuestId))
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
            ViewData["QuestId"] = new SelectList(_context.Quests, "QuestId", "QuestId", collaborativeQuest.QuestId);
            return View(collaborativeQuest);
        }

        // GET: CollaborativeQuests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborativeQuest = await _context.CollaborativeQuests
                .Include(c => c.Quest)
                .FirstOrDefaultAsync(m => m.QuestId == id);
            if (collaborativeQuest == null)
            {
                return NotFound();
            }

            return View(collaborativeQuest);
        }

        // POST: CollaborativeQuests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collaborativeQuest = await _context.CollaborativeQuests.FindAsync(id);
            if (collaborativeQuest != null)
            {
                _context.CollaborativeQuests.Remove(collaborativeQuest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaborativeQuestExists(int id)
        {
            return _context.CollaborativeQuests.Any(e => e.QuestId == id);
        }
    }
}
