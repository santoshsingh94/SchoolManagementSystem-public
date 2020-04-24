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
    public class StudentCertificateReportsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentCertificateReportsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult LeavingC(int ? id)
        {
            ViewBag.Message = "Ready to Print";
            var student = _context.StudentPromotes.Where(s => s.StudentId == id && s.IsActive == true)
                        .Include(s => s.Student)
                        .Include(s => s.ClassTbl)
                        .FirstOrDefault();
            if (student==null)
            {
                ViewBag.Message = "Already Printed";
                student = _context.StudentPromotes.Where(s => s.StudentId == id)
                        .Include(s => s.Student)
                        .Include(s => s.ClassTbl)
                        .OrderByDescending(e => e.StudentPromoteId).FirstOrDefault();
                return View(student);
            }            
            return View(student);
        }
         public IActionResult PrintLeavingC(int? id)
        {
            var student = _context.StudentPromotes.Where(s => s.StudentId == id && s.IsActive == true)                        
                        .Include(s => s.Student)
                        .FirstOrDefault();
            if (student ==null)
            {
                ViewBag.Message = "Certificate Already Printed! Please Contact to Administration Department.";
                student = _context.StudentPromotes.Where(s => s.StudentId == id)
                        .Include(s => s.Student)
                        .Include(s => s.ClassTbl)
                        .OrderByDescending(e => e.StudentPromoteId).FirstOrDefault();
                return View("LeavingC", student);
            }
            student.IsActive = false;
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            ViewBag.Message = "Printed Successfully.";
            return View("LeavingC",student);
        }
        public IActionResult ProvisionalC()
        {
            return View();
        }
        public IActionResult CharacterC(int ? id)
        {
            ViewBag.Message = "Ready to Print";
            var student = _context.StudentPromotes.Where(s => s.StudentId == id && s.IsActive == true)
                        .Include(s => s.Student)
                        .Include(s => s.ClassTbl)
                        .FirstOrDefault();
            if (student == null)
            {
                ViewBag.Message = "Already Printed";
                student = _context.StudentPromotes.Where(s => s.StudentId == id)
                        .Include(s => s.Student)
                        .Include(s => s.ClassTbl)
                        .OrderByDescending(e => e.StudentPromoteId).FirstOrDefault();
                return View(student);
            }
            return View(student);
        }
    }
}