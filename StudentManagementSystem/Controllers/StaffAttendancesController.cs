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
    public class StaffAttendancesController : Controller
    {
        private readonly AppDbContext _context;

        public StaffAttendancesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StaffAttendances
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            var appDbContext = _context.StaffAttendances.Include(s => s.Staff);
            return View(await appDbContext.ToListAsync());
        }

        // GET: StaffAttendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var staffAttendance = await _context.StaffAttendances
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffAttendanceId == id);
            if (staffAttendance == null)
            {
                return NotFound();
            }

            return View(staffAttendance);
        }

        // GET: StaffAttendances/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Name");
            return View();
        }

        // POST: StaffAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( StaffAttendance staffAttendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffAttendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs.Where(s=>s.IsActive==true), "StaffId", "Name", staffAttendance.StaffId);
            return View(staffAttendance);
        }

        // GET: StaffAttendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var staffAttendance = await _context.StaffAttendances.FindAsync(id);
            if (staffAttendance == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId", staffAttendance.StaffId);
            return View(staffAttendance);
        }

        // POST: StaffAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,StaffAttendance staffAttendance)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id != staffAttendance.StaffAttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffAttendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffAttendanceExists(staffAttendance.StaffAttendanceId))
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
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId", staffAttendance.StaffId);
            return View(staffAttendance);
        }

        // GET: StaffAttendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var staffAttendance = await _context.StaffAttendances
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffAttendanceId == id);
            if (staffAttendance == null)
            {
                return NotFound();
            }

            return View(staffAttendance);
        }

        // POST: StaffAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            var staffAttendance = await _context.StaffAttendances.FindAsync(id);
            _context.StaffAttendances.Remove(staffAttendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffAttendanceExists(int id)
        {
            return _context.StaffAttendances.Any(e => e.StaffAttendanceId == id);
        }
    }
}
