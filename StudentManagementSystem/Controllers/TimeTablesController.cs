using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class TimeTablesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public TimeTablesController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        // GET: TimeTables
        public async Task<IActionResult> Index()
        {
            
            var appDbContext = _context.TimeTables.Include(t => t.ClassSubject).Include(t => t.Staff).Include(t => t.ApplicationUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TimeTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTables
                .Include(t => t.ClassSubject)
                .Include(t => t.Staff)
                .Include(t => t.ApplicationUser)
                .FirstOrDefaultAsync(m => m.TimeTableId == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // GET: TimeTables/Create
        public IActionResult Create()
        {
           
            ViewData["ClassSubjectId"] = new SelectList(_context.ClassSubjects, "ClassSubjectId", "Name");
            ViewData["StaffId"] = new SelectList(_context.Staffs.Where(s=>s.IsActive==true), "StaffId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeTable timeTable)
        {
            var user = await GetCurrentUserAsync();
            timeTable.ApplicationUserId = user?.Id;

            if (ModelState.IsValid)
            {
                _context.Add(timeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassSubjectId"] = new SelectList(_context.ClassSubjects, "ClassSubjectId", "ClassSubjectId", timeTable.ClassSubjectId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId", timeTable.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", timeTable.ApplicationUserId);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTables.FindAsync(id);
            if (timeTable == null)
            {
                return NotFound();
            }
            ViewData["ClassSubjectId"] = new SelectList(_context.ClassSubjects, "ClassSubjectId", "Name", timeTable.ClassSubjectId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Name", timeTable.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", timeTable.ApplicationUserId);
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TimeTable timeTable)
        {
            var user = await GetCurrentUserAsync();
            timeTable.ApplicationUserId = user?.Id;

            if (id != timeTable.TimeTableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTableExists(timeTable.TimeTableId))
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
            ViewData["ClassSubjectId"] = new SelectList(_context.ClassSubjects, "ClassSubjectId", "ClassSubjectId", timeTable.ClassSubjectId);
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId", timeTable.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", timeTable.ApplicationUserId);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTables
                .Include(t => t.ClassSubject)
                .Include(t => t.Staff)
                .Include(t => t.ApplicationUser)
                .FirstOrDefaultAsync(m => m.TimeTableId == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeTable = await _context.TimeTables.FindAsync(id);
            _context.TimeTables.Remove(timeTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeTableExists(int id)
        {
            return _context.TimeTables.Any(e => e.TimeTableId == id);
        }
    }
}
