using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.ViewModels;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class AttendanceReportsController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceReportsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult StudentAttendance(int? id)
        {
            if (id == 0)
            {
                int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                //id = _context.Students.Where(s => s.UserId == userid).FirstOrDefault().StudentId;
                string userName = HttpContext.Session.GetString("UserName");
                Student student = _context.Students.Where(s => s.Email == userName).FirstOrDefault();
                if (student != null)
                {
                    id = student.StudentId;
                }
            }

            var attendance = _context.Attendances.Where(a => a.StudentId == id)
                .Include(s => s.Student)
                .Include(c => c.ClassTbl)
                .Include(s => s.Session);
            return View(attendance);
        }

        public IActionResult AllStudentAttendance()
        {
            var attendance = _context.Attendances
                .Include(s => s.Student)
                .Include(c => c.ClassTbl)
                .Include(s => s.Session)
                .OrderByDescending(a => a.AttendanceDate);
            return View(attendance);
        }
        public IActionResult StaffAttendance(int? id)
        {
            if (id == 0)
            {
                string userName = HttpContext.Session.GetString("UserName");
                Staff staff = _context.Staffs.Where(s => s.Email == userName).FirstOrDefault();
                if (staff != null)
                {
                    id = staff.StaffId;
                }
            }
            List<StaffAttendanceReport> staffAttendanceList = new List<StaffAttendanceReport>();
            var staffAttendance = _context.StaffAttendances.Where(s => s.StaffId == id)
                                .Include(s => s.Staff)
                                .Include(d => d.Staff.Designation)
                                .OrderByDescending(a => a.StaffAttendanceId);
            foreach (var item in staffAttendance)
            {
                staffAttendanceList.Add(new StaffAttendanceReport
                {
                    Name = item.Staff.Name,
                    Designation = item.Staff.Designation.Title,
                    AttendanceDate = item.AttendanceDate,
                    ComingTime = item.ComingTime,
                    ClosingTime = item.ClosingTime,
                    DutyHour = (TimeSpan)item.ClosingTime - (TimeSpan)item.ComingTime
                });
            }
            return View(staffAttendanceList);
        }

        public IActionResult AllStaffAttendance()
        {
            List<StaffAttendanceReport> staffAttendanceList = new List<StaffAttendanceReport>();
            var staffAttendance = _context.StaffAttendances
                                .Include(s => s.Staff)
                                .Include(d => d.Staff.Designation)
                                .OrderByDescending(a => a.StaffAttendanceId);
            foreach (var item in staffAttendance)
            {
                staffAttendanceList.Add(new StaffAttendanceReport
                {
                    Name = item.Staff.Name,
                    Designation = item.Staff.Designation.Title,
                    AttendanceDate = item.AttendanceDate,
                    ComingTime = item.ComingTime,
                    ClosingTime = item.ClosingTime,
                    DutyHour = (TimeSpan)item.ClosingTime - (TimeSpan)item.ComingTime
                });
            }
            return View(staffAttendanceList);
        }
    }
}