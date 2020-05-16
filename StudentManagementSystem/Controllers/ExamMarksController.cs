 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class ExamMarksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public ExamMarksController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        // GET: ExamMarks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ExamMarks
                                .Include(e => e.ClassSubject)
                                .Include(e => e.Exam)
                                .Include(e => e.Student)
                                .Include(e => e.ApplicationUser)
                                .OrderByDescending(e=>e.ExamMarkId);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ExamMarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {           
            if (id == null)
            {
                return NotFound();
            }

            var examMark = await _context.ExamMarks
                .Include(e => e.ClassSubject)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ExamMarkId == id);
            if (examMark == null)
            {
                return NotFound();
            }

            return View(examMark);
        }

        // GET: ExamMarks/Create
        public IActionResult Create()
        {
            return View();
        }
        //Ajax Call
        public ActionResult GetByPromoteId(string sid)
        {
            int promoteId = Convert.ToInt32(sid);
            var promoteRecord = _context.StudentPromotes.Find(promoteId);
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student { StudentId = promoteRecord.StudentId, Name = _context.Students.Find(promoteRecord.StudentId).Name });
            List<ClassSubject> classSubjectList = new List<ClassSubject>();
            var subjects = _context.ClassSubjects.Where(cls => cls.ClassTblId == promoteRecord.ClassTblId && cls.IsActive==true);
            foreach (var sub in subjects)
            {
                classSubjectList.Add(new ClassSubject
                {
                    ClassSubjectId = sub.ClassSubjectId,
                    Name = sub.Name
                });
            }
            //var student = studentList[0].Name;
            var data = new { studentList, classSubjectList };
            return Json(data);
        }
        public ActionResult GetTotalMarks(string sid)
        {
            int classSubjectId = Convert.ToInt32(sid);
            var classSubject = _context.ClassSubjects.Find(classSubjectId);
            var totalMarks = _context.Subjects.Find(classSubject.SubjectId).TotalMarks;
            return Json(totalMarks);
        }

        // POST: ExamMarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamMark examMark)
        {
            var user = await GetCurrentUserAsync();
            examMark.ApplicationUserId = user?.Id;

            if (ModelState.IsValid)
            {
                _context.Add(examMark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(examMark);
        }

        // GET: ExamMarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            var examMark = await _context.ExamMarks.FindAsync(id);
            if (examMark == null)
            {
                return NotFound();
            };
            return View(examMark);
        }

        // POST: ExamMarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExamMarkId,ExamId,ClassSubjectId,StudentId,UserId,TotalMarks,ObtainMarks")] ExamMark examMark)
        {
            var user = await GetCurrentUserAsync();
            examMark.ApplicationUserId = user?.Id;

            if (id != examMark.ExamMarkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examMark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamMarkExists(examMark.ExamMarkId))
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
            return View(examMark);
        }

        // GET: ExamMarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var examMark = await _context.ExamMarks
                .Include(e => e.ClassSubject)
                .Include(e => e.Exam)
                .Include(e => e.Student)
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ExamMarkId == id);
            if (examMark == null)
            {
                return NotFound();
            }

            return View(examMark);
        }

        // POST: ExamMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            var examMark = await _context.ExamMarks.FindAsync(id);
            _context.ExamMarks.Remove(examMark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamMarkExists(int id)
        {
            return _context.ExamMarks.Any(e => e.ExamMarkId == id);
        }
    }
}
