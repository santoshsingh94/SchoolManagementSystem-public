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

namespace StudentManagementSystem.Controllers
{
    public class AnnualsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public AnnualsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        // GET: Annuals
        public async Task<IActionResult> Index()
        {
            
            //var appDbContext = _context.Annuals.Include(a => a.Programe).Include(a => a.User);
            var appDbContext = _context.Annuals.Include(a => a.Programe).Include(a => a.ApplicationUser).Where(p=>p.IsActive==true);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Annuals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var annual = await _context.Annuals
                .Include(a => a.Programe)
                .Include(a => a.ApplicationUser)
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
            
            
            return View();
        }

        // POST: Annuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Annual annual)
        {
            var user = await GetCurrentUserAsync();
            annual.ApllicationUserId = user?.Id;

            if (ModelState.IsValid)
            {
                _context.Add(annual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(annual);
        }

        // GET: Annuals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var annual = await _context.Annuals.FindAsync(id);
            if (annual == null)
            {
                return NotFound();
            }
            
            return View(annual);
        }

        // POST: Annuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Annual annual)
        {
            var user = await GetCurrentUserAsync();
            annual.ApllicationUserId = user?.Id;

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
            
            return View(annual);
        }

        // GET: Annuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var annual = await _context.Annuals
                .Include(a => a.Programe)
                .Include(a => a.ApplicationUser)
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
