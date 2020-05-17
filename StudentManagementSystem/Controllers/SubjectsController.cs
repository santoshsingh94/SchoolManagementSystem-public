using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class SubjectsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public SubjectsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        //Finding Application User
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Subjects.Include(s => s.ApplicationUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }
        
        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subject subject)
        {
            var model = _context.Subjects.Where(s => s.Name.Trim() == subject.Name.Trim()).FirstOrDefault();
            if (model==null)
            {
                var user = await GetCurrentUserAsync();
                subject.ApplicationUserId = user?.Id;
                if (ModelState.IsValid)
                {
                    _context.Add(subject);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError(string.Empty, "Subject already exists.");
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subject subject)
        {            
            if (id != subject.SubjectId)
            {
                return NotFound();
            }
            var result = _context.Subjects.Where(s => s.Name.Trim() == subject.Name.Trim() && s.SubjectId!=id).ToList();
            if (result.Count==0)
            {                
                var user = await GetCurrentUserAsync();
                subject.ApplicationUserId = user?.Id;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(subject);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SubjectExists(subject.SubjectId))
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
            }
            ModelState.AddModelError(string.Empty, "Subject already exists.");
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subject = await _context.Subjects
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
