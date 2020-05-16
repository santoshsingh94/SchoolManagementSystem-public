using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class ExamReportsController : Controller
    {
        private readonly AppDbContext _context;
        public ExamReportsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult PrintMarkSheet()
        {
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "Title");
            return View(new List<ExamMark>());
        }

        [HttpPost]
        public IActionResult PrintMarkSheet(int ? promoteId, int ? examId)
        {
            float totalMarks = 0; 
            var promoteRecord = _context.StudentPromotes.Find(promoteId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "Title");
            if (promoteRecord != null)
            {
                var listMarks = _context.ExamMarks
                    .Where(e => e.ClassSubject.ClassTblId == promoteRecord.ClassTblId && e.StudentId == promoteRecord.StudentId)
                    .Include(s => s.Student)
                    .Include(c => c.ClassSubject)
                    .Include(u => u.ApplicationUser);
                if (listMarks!=null)
                {

                }

                return View(listMarks);
            }            
            return View(new List<ExamMark>());
        }
    }
}