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
    public class ClassSubjectsController : Controller
    {
        private readonly AppDbContext _context;

        public ClassSubjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClassSubjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ClassSubjects.Include(c => c.ClassTbl).Include(c => c.Subject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ClassSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSubject = await _context.ClassSubjects
                .Include(c => c.ClassTbl)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.ClassSubjectId == id);
            if (classSubject == null)
            {
                return NotFound();
            }

            return View(classSubject);
        }

        // GET: ClassSubjects/Create
        public IActionResult Create()
        {
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls.Where(c => c.IsActive == true), "ClassTblId", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name");
            return View();
        }

        // POST: ClassSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassSubject classSubject)
        {
            if (ModelState.IsValid)
            {
                var classname = _context.ClassTbls.Where(c => c.ClassTblId == classSubject.ClassTblId).SingleOrDefault();
                var subjectname = _context.Subjects.Where(c => c.SubjectId == classSubject.SubjectId).SingleOrDefault();
                if (classname != null)
                {
                    classSubject.Name = subjectname.Name + "-" + classname.Name;
                    var model = _context.ClassSubjects.Where(s => s.Name.Trim() == classSubject.Name.Trim()).FirstOrDefault();
                    if (model != null)
                    {
                        ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", classSubject.ClassTblId);
                        ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name", classSubject.SubjectId);
                        ModelState.AddModelError(string.Empty, "Class-Subject already exists.Please select another Class-Subject Combination.");
                        return View(classSubject);
                    }
                    _context.Add(classSubject);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }               
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls.Where(c => c.IsActive == true), "ClassTblId", "ClassTblId", classSubject.ClassTblId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", classSubject.SubjectId);
            return View(classSubject);
        }

        // GET: ClassSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSubject = await _context.ClassSubjects.FindAsync(id);
            if (classSubject == null)
            {
                return NotFound();
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", classSubject.ClassTblId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name", classSubject.SubjectId);
            return View(classSubject);
        }

        // POST: ClassSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassSubject classSubject)
        {
            if (id != classSubject.ClassSubjectId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var classname = _context.ClassTbls.Where(c => c.ClassTblId == classSubject.ClassTblId).SingleOrDefault();
                var subjectname = _context.Subjects.Where(c => c.SubjectId == classSubject.SubjectId).SingleOrDefault();
                if (classname != null)
                {
                    classSubject.Name = subjectname.Name + "-" + classname.Name;
                    var model = _context.ClassSubjects.Where(s => s.Name.Trim() == classSubject.Name.Trim() && s.ClassSubjectId != id).ToList();
                    if (model.Count != 0)
                    {
                        ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", classSubject.ClassTblId);
                        ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name", classSubject.SubjectId);
                        ModelState.AddModelError(string.Empty, "Class-Subject already exists.Please select another Class-Subject Combination.");
                        return View(classSubject);
                    }
                    try
                    {
                        _context.Update(classSubject);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClassSubjectExists(classSubject.ClassSubjectId))
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
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", classSubject.ClassTblId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "Name", classSubject.SubjectId);
            return View(classSubject);
        }

        // GET: ClassSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSubject = await _context.ClassSubjects
                .Include(c => c.ClassTbl)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(m => m.ClassSubjectId == id);
            if (classSubject == null)
            {
                return NotFound();
            }

            return View(classSubject);
        }

        // POST: ClassSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classSubject = await _context.ClassSubjects.FindAsync(id);
            _context.ClassSubjects.Remove(classSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassSubjectExists(int id)
        {
            return _context.ClassSubjects.Any(e => e.ClassSubjectId == id);
        }
    }
}
