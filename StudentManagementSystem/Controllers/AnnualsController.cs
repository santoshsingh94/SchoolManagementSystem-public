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

namespace StudentManagementSystem.Controllers
{
    public class AnnualsController : Controller
    {
        private readonly AppDbContext _context;

        public AnnualsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Annuals
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            //var appDbContext = _context.Annuals.Include(a => a.Programe).Include(a => a.User);
            var appDbContext = _context.Annuals.Include(a => a.Programe).Include(a => a.User).Where(p=>p.IsActive==true);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Annuals/Details/5
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

            var annual = await _context.Annuals
                .Include(a => a.Programe)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnualId == id);
            if (annual == null)
            {
                return NotFound();
            }

            return View(annual);
        }

        // GET: Annuals/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["ProgrameId"] = new SelectList(_context.Programes.Where(p=>p.IsActive==true), "ProgrameId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: Annuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Annual annual)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            annual.UserId = userid;

            if (ModelState.IsValid)
            {
                _context.Add(annual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgrameId"] = new SelectList(_context.Programes.Where(p => p.IsActive == true), "ProgrameId", "ProgrameId", annual.ProgrameId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", annual.UserId);
            return View(annual);
        }

        // GET: Annuals/Edit/5
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

            var annual = await _context.Annuals.FindAsync(id);
            if (annual == null)
            {
                return NotFound();
            }
            ViewData["ProgrameId"] = new SelectList(_context.Programes.Where(p => p.IsActive == true), "ProgrameId", "Name", annual.ProgrameId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", annual.UserId);
            return View(annual);
        }

        // POST: Annuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Annual annual)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            annual.UserId = userid;

            if (id != annual.AnnualId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnualExists(annual.AnnualId))
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
            ViewData["ProgrameId"] = new SelectList(_context.Programes.Where(p => p.IsActive == true), "ProgrameId", "ProgrameId", annual.ProgrameId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", annual.UserId);
            return View(annual);
        }

        // GET: Annuals/Delete/5
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

            var annual = await _context.Annuals
                .Include(a => a.Programe)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnualId == id);
            if (annual == null)
            {
                return NotFound();
            }

            return View(annual);
        }

        // POST: Annuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var annual = await _context.Annuals.FindAsync(id);
            _context.Annuals.Remove(annual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnualExists(int id)
        {
            return _context.Annuals.Any(e => e.AnnualId == id);
        }
    }
}
