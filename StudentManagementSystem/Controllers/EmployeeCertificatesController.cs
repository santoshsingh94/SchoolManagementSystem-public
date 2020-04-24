using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class EmployeeCertificatesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeCertificatesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ExperienceC(int ? id)
        {
            var employee = _context.Staffs.Where(s => s.StaffId == id)
                .Include(d=>d.Designation)
                .FirstOrDefault();
            ViewBag.FromDate = employee.RegistrationDate.ToString("yyyy/MM/dd");
            if (employee.StaffAttendances.Count != 0)
            {
                ViewBag.ToDate = employee.StaffAttendances.OrderByDescending(s => s.AttendanceDate).FirstOrDefault().AttendanceDate;
            }
            else
            {
                ViewBag.ToDate = DateTime.Now.ToString("yyyy/MM/dd");
            }
            return View(employee);
        }
    }
}