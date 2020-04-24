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
    public class StudentPromotesController : Controller
    {
        private readonly AppDbContext _context;

        public StudentPromotesController(AppDbContext context)
        {
            _context = context;
        }

        //Ajax Call
        public ActionResult GetPromoteList(string sId)
        {
            int studentId = Convert.ToInt32(sId);
            var student = _context.Students.Find(studentId);
            int promoteId = 0;
            try
            {
                promoteId = _context.StudentPromotes.Where(p => p.StudentId == studentId).Max(m=>m.StudentPromoteId);//Max(m=>(int?)m .StudentPromoteId)

            }
            catch (Exception)
            {
                promoteId=0;
            }
            List<ClassTbl> classTbl = new List<ClassTbl>();
            if (promoteId>0)
            {
                var promoteTable = _context.StudentPromotes.Find(promoteId);
                foreach (var item in _context.ClassTbls.Where(cls=>cls.ClassTblId > promoteTable.ClassTblId))
                {
                    classTbl.Add(new ClassTbl { ClassTblId = item.ClassTblId, Name = item.Name });
                }
            }
            foreach (var cls in _context.ClassTbls.Where(c => c.ClassTblId > student.ClassTblId))
            {
                classTbl.Add(new ClassTbl { ClassTblId = cls.ClassTblId, Name = cls.Name });
            }
            //var data = JsonConvert.SerializeObject(classTbl);, new JsonSerializerSettings()
            //return data;new { data = classTbl}
            return Json(classTbl);
        }
        public ActionResult GetAnnualFees(string pSId)
        {
            int programeSessionId = Convert.ToInt32(pSId);
            var ps = _context.ProgrameSessions.Find(programeSessionId);
            var annualFee = _context.Annuals.Where(a => a.AnnualId == ps.ProgrameId).SingleOrDefault();
            double? fee = annualFee.Fees;
            return Json(fee);
        }


        // GET: StudentPromotes
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var appDbContext = _context.StudentPromotes
                .Include(s => s.ClassTbl)
                .Include(s => s.ProgrameSession)
                .Include(s => s.Section)
                .Include(s => s.Student)
                .OrderByDescending(s=>s.StudentPromoteId);
            return View(await appDbContext.ToListAsync());
        }

        // GET: StudentPromotes/Details/5
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

            var studentPromote = await _context.StudentPromotes
                .Include(s => s.ClassTbl)
                .Include(s => s.ProgrameSession)
                .Include(s => s.Section)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPromoteId == id);
            if (studentPromote == null)
            {
                return NotFound();
            }

            return View(studentPromote);
        }

        // GET: StudentPromotes/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name");
            ViewData["ProgrameSessionId"] = new SelectList(_context.ProgrameSessions, "ProgrameSessionId", "Details");
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name");
            return View();
        }

        // POST: StudentPromotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentPromote studentPromote)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                _context.Add(studentPromote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", studentPromote.ClassTblId);
            ViewData["ProgrameSessionId"] = new SelectList(_context.ProgrameSessions, "ProgrameSessionId", "Details", studentPromote.ProgrameSessionId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "Name", studentPromote.SectionId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name", studentPromote.StudentId);
            return View(studentPromote);
        }

        // GET: StudentPromotes/Edit/5
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

            var studentPromote = await _context.StudentPromotes.FindAsync(id);
            if (studentPromote == null)
            {
                return NotFound();
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", studentPromote.ClassTblId);
            ViewData["ProgrameSessionId"] = new SelectList(_context.ProgrameSessions, "ProgrameSessionId", "Details", studentPromote.ProgrameSessionId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "Name", studentPromote.SectionId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name", studentPromote.StudentId);
            return View(studentPromote);
        }

        // POST: StudentPromotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentPromote studentPromote)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id != studentPromote.StudentPromoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentPromote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPromoteExists(studentPromote.StudentPromoteId))
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
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "ClassTblId", studentPromote.ClassTblId);
            ViewData["ProgrameSessionId"] = new SelectList(_context.ProgrameSessions, "ProgrameSessionId", "ProgrameSessionId", studentPromote.ProgrameSessionId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", studentPromote.SectionId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "ContactNo", studentPromote.StudentId);
            return View(studentPromote);
        }

        // GET: StudentPromotes/Delete/5
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

            var studentPromote = await _context.StudentPromotes
                .Include(s => s.ClassTbl)
                .Include(s => s.ProgrameSession)
                .Include(s => s.Section)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentPromoteId == id);
            if (studentPromote == null)
            {
                return NotFound();
            }

            return View(studentPromote);
        }

        // POST: StudentPromotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var studentPromote = await _context.StudentPromotes.FindAsync(id);
            _context.StudentPromotes.Remove(studentPromote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPromoteExists(int id)
        {
            return _context.StudentPromotes.Any(e => e.StudentPromoteId == id);
        }
    }
}
