using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class FeeReportsController : Controller
    {
        private readonly AppDbContext _context;

        public FeeReportsController(AppDbContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public IActionResult CustomTutionFee()
        {
            var allTutionFee = _context.SubmissionFees
                .Where(e => e.SubmissionDate  >= DateTime.Now && e.SubmissionDate <= DateTime.Now)
                .Include(e => e.ClassTbl)
                .Include(e=>e.Student)
                .Include(u => u.User)
                .ToList()
                .OrderByDescending(e => e.SubmissionFeeId);
            return View(allTutionFee);
        }
        [HttpPost]
        public IActionResult CustomTutionFee(DateTime fromDate, DateTime toDate)
        {
            var allTutionFee = _context.SubmissionFees
               .Where(e => e.SubmissionDate >= fromDate && e.SubmissionDate <= toDate)
                .Include(e => e.ClassTbl)
                .Include(e => e.Student)
                .Include(u => u.User)
                .ToList()
               .OrderByDescending(e => e.SubmissionFeeId);
            return View(allTutionFee);
        }

        [HttpGet]
        public IActionResult CustomAnnualFee()
        {
            var allAnnualFee = _context.StudentPromotes
                .Where(e => e.PromoteDate >= DateTime.Now && e.PromoteDate <= DateTime.Now && e.IsSubmit==true)
                .Include(e => e.ClassTbl)
                .Include(e => e.Student)
                .Include(u => u.ProgrameSession.Session)
                .ToList()
                .OrderByDescending(e => e.StudentPromoteId);
            return View(allAnnualFee);
        }
        [HttpPost]
        public IActionResult CustomAnnualFee(DateTime fromDate, DateTime toDate)
        {
            var allAnnualFee = _context.StudentPromotes
                 .Where(e => e.PromoteDate >= fromDate && e.PromoteDate <= toDate && e.IsSubmit == true)
                 .Include(e => e.ClassTbl)
                 .Include(e => e.Student)
                 .Include(u => u.ProgrameSession.Session)
                 .ToList()
                 .OrderByDescending(e => e.StudentPromoteId);
            return View(allAnnualFee);
        }
    }
}