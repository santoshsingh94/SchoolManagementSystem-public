using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly AppDbContext _context;

        public AttendancesController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult GetByPromoteId(string sid)
        {
            if (sid != null)
            {
                int promoteId = Convert.ToInt32(sid);
                var promoteRecord = _context.StudentPromotes.Find(promoteId);
                if (promoteRecord != null)
                {
                    var StudentId = promoteRecord.StudentId;
                    var ClassId = promoteRecord.ClassTblId;
                    var gettingPrograme = _context.ProgrameSessions.Find(promoteRecord.ProgrameSessionId);
                    var ProgrameId = gettingPrograme.ProgrameId;
                    return Json(new { StudentId, ClassId, ProgrameId });
                }
                else
                {
                    //ViewBag.Message = "PromoteId does not exist!!";
                    return null;
                }
            }
            return null;
        }


        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Attendances
                .Include(a => a.ClassTbl)
                .Include(a => a.Session)
                .Include(a => a.Student)
                .OrderByDescending(a => a.AttendanceId);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.ClassTbl)
                .Include(a => a.Session)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name");
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", attendance.ClassTblId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "Name", attendance.SessionId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name", attendance.StudentId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", attendance.ClassTblId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "Name", attendance.SessionId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name", attendance.StudentId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceId))
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
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "ClassTblId", attendance.ClassTblId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "SessionId", attendance.SessionId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", attendance.StudentId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.ClassTbl)
                .Include(a => a.Session)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendances.Any(e => e.AttendanceId == id);
        }
    }
}
