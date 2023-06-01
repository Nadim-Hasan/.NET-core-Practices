using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rank.Data;
using Rank.Model;

namespace Rank.Pages
{
    public class TaskEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskEntries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskEntries.Include(t => t.Category).Include(t => t.People);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskEntries == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntries
                .Include(t => t.Category)
                .Include(t => t.People)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntry == null)
            {
                return NotFound();
            }

            return View(taskEntry);
        }

        // GET: TaskEntries/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["peopleId"] = new SelectList(_context.Pleoples, "Id", "Name");
            return View();
        }

        // POST: TaskEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,peopleId,CategoryId,TaskTypeId,Note,Mark,Details,CreateDate,UpdateDate,UserId,FilePath,statusId")] TaskEntry taskEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", taskEntry.CategoryId);
            ViewData["peopleId"] = new SelectList(_context.Pleoples, "Id", "Name", taskEntry.peopleId);
            return View(taskEntry);
        }

        // GET: TaskEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskEntries == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntries.FindAsync(id);
            if (taskEntry == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", taskEntry.CategoryId);
            ViewData["peopleId"] = new SelectList(_context.Pleoples, "Id", "Name", taskEntry.peopleId);
            return View(taskEntry);
        }

        // POST: TaskEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,peopleId,CategoryId,TaskTypeId,Note,Mark,Details,CreateDate,UpdateDate,UserId,FilePath,statusId")] TaskEntry taskEntry)
        {
            if (id != taskEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskEntryExists(taskEntry.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", taskEntry.CategoryId);
            ViewData["peopleId"] = new SelectList(_context.Pleoples, "Id", "Name", taskEntry.peopleId);
            return View(taskEntry);
        }

        // GET: TaskEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskEntries == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntries
                .Include(t => t.Category)
                .Include(t => t.People)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntry == null)
            {
                return NotFound();
            }

            return View(taskEntry);
        }

        // POST: TaskEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskEntries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaskEntries'  is null.");
            }
            var taskEntry = await _context.TaskEntries.FindAsync(id);
            if (taskEntry != null)
            {
                _context.TaskEntries.Remove(taskEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEntryExists(int id)
        {
          return (_context.TaskEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
