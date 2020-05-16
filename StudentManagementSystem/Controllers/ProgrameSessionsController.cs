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
    public class ProgrameSessionsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public ProgrameSessionsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        // GET: ProgrameSessions
        public async Task<IActionResult> Index()
        {
            
            var appDbContext = _context.ProgrameSessions.Include(p => p.Programe).Include(p => p.Session).Include(p => p.ApplicationUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProgrameSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programeSession = await _context.ProgrameSessions
                .Include(p => p.Programe)
                .Include(p => p.Session)
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProgrameSessionId == id);
            if (programeSession == null)
            {
                return NotFound();
            }

            return View(programeSession);
        }

        // GET: ProgrameSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgrameSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgrameSession programeSession)
        {
            var user = await GetCurrentUserAsync();
            programeSession.ApplicationUserId = user?.Id;
            if (ModelState.IsValid)
            {
                var sessionname = _context.Sessions.Where(s => s.SessionId == programeSession.SessionId).SingleOrDefault();
                var programename = _context.Programes.Where(s => s.ProgrameId == programeSession.ProgrameId).SingleOrDefault();
                if (sessionname != null)
                {
                    if (!programeSession.Details.Contains(sessionname.Name))
                    {
                        var details = "(" + sessionname.Name + "-" + (programename !=null ? programename.Name : "") + ")" + programeSession.Details;
                        programeSession.Details = details;
                    }
                }                
                _context.Add(programeSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programeSession);
        }

        // GET: ProgrameSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var programeSession = await _context.ProgrameSessions.FindAsync(id);
            if (programeSession == null)
            {
                return NotFound();
            }
            return View(programeSession);
        }

        // POST: ProgrameSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProgrameSession programeSession)
        {
            var user = await GetCurrentUserAsync();
            programeSession.ApplicationUserId = user?.Id;
            if (id != programeSession.ProgrameSessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sessionname = _context.Sessions.Where(s => s.SessionId == programeSession.SessionId).SingleOrDefault();
                var programename = _context.Programes.Where(s => s.ProgrameId == programeSession.ProgrameId).SingleOrDefault();
                if (sessionname != null)
                {
                    if (!programeSession.Details.Contains(sessionname.Name))
                    {
                        var details = "(" + sessionname.Name + "-" + (programename != null ? programename.Name : "") + ")" + programeSession.Details;
                        programeSession.Details = details;
                    }
                }
                try
                {
                    _context.Update(programeSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrameSessionExists(programeSession.ProgrameSessionId))
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
            return View(programeSession);
        }

        // GET: ProgrameSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programeSession = await _context.ProgrameSessions
                .Include(p => p.Programe)
                .Include(p => p.Session)
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProgrameSessionId == id);
            if (programeSession == null)
            {
                return NotFound();
            }

            return View(programeSession);
        }

        // POST: ProgrameSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var programeSession = await _context.ProgrameSessions.FindAsync(id);
            _context.ProgrameSessions.Remove(programeSession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrameSessionExists(int id)
        {
            return _context.ProgrameSessions.Any(e => e.ProgrameSessionId == id);
        }
    }
}
