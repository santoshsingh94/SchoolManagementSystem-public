using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class TimeTableReportsController : Controller
    {
        private readonly AppDbContext _context;

        public TimeTableReportsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult TeacherReport(int ? id)
        {
            var teacherClass = _context.TimeTables.Where(t => t.StaffId == id)
                .Include(e=>e.ClassSubject)
                .Include(e=>e.ApplicationUser)
                .OrderByDescending(e => e.TimeTableId);          
            return View(teacherClass);
        }
        public IActionResult TeacherWiseReport()
        {
            var teacherClass = _context.TimeTables.Where(t=>t.IsActive==true)
                .Include(e => e.ClassSubject)
                .Include(e=>e.Staff)
                .Include(e => e.ApplicationUser)
                .OrderBy(e => e.StaffId);
            return View(teacherClass);
        }

        public IActionResult StudentReport(int? id)
        {
            var classId = _context.StudentPromotes.Where(p => p.StudentId == id && p.IsActive == true).FirstOrDefault().ClassTblId;
            //var classSubjects = _context.ClassSubjects.Where(cls => cls.ClassTblId == classId && cls.IsActive == true);
            //List<TimeTable> timeTables = new List<TimeTable>();
            //foreach (var classSubject in classSubjects)
            //{
            //    var subjectTime = _context.TimeTables.Where(t => t.ClassSubjectId == classSubject.ClassSubjectId && t.IsActive == true).FirstOrDefault();
            //    timeTables.Add(subjectTime);
            //}

            var subjectTime = _context.TimeTables.Where(t => t.ClassSubject.ClassTblId == classId && t.IsActive == true)
                            .Include(u=>u.ApplicationUser)
                            .Include(u=>u.ClassSubject)
                            .Include(t=>t.Staff);
            return View(subjectTime);
        }
    }
}