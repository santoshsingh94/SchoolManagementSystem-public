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
    public class EmployeeSalariesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeSalariesController(AppDbContext context)
        {
            _context = context;
        }

        //Ajax call to get emp salary
        public ActionResult GetSalary(string sid)
        {
            int staffId = Convert.ToInt32(sid);
            var staffData = _context.Staffs.Find(staffId);
            double? salary = staffData.BasicSalary;
            return Json(salary);
        }

        // GET: EmployeeSalaries
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var appDbContext = _context.EmployeeSalarys.Include(e => e.Staff).Include(e => e.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EmployeeSalaries/Details/5
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

            var employeeSalary = await _context.EmployeeSalarys
                .Include(e => e.Staff)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EmployeeSalaryId == id);
            if (employeeSalary == null)
            {
                return NotFound();
            }

            return View(employeeSalary);
        }

        // GET: EmployeeSalaries/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            EmployeeSalary employeeSalary = new EmployeeSalary();
            employeeSalary.SalaryMonth = DateTime.Now.AddMonths(-1).ToString("MMMM");
            employeeSalary.SalaryDate = DateTime.Now;
            employeeSalary.SalaryYear = DateTime.Now.ToString("yyyy");
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeSalary employeeSalary)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            employeeSalary.UserId = userid;
            if (ModelState.IsValid)
            {
                _context.Add(employeeSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Name", employeeSalary.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", employeeSalary.UserId);
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalarys.FindAsync(id);
            if (employeeSalary == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "Name", employeeSalary.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", employeeSalary.UserId);
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeSalaryId,UserId,StaffId,Amount,SalaryMonth,SalaryYear,SalaryDate,Comments")] EmployeeSalary employeeSalary)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            employeeSalary.UserId = userid;
            if (id != employeeSalary.EmployeeSalaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSalaryExists(employeeSalary.EmployeeSalaryId))
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
            ViewData["StaffId"] = new SelectList(_context.Staffs.Where(s=>s.IsActive==true), "Name", "Address", employeeSalary.StaffId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", employeeSalary.UserId);
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalarys
                .Include(e => e.Staff)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EmployeeSalaryId == id);
            if (employeeSalary == null)
            {
                return NotFound();
            }

            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var employeeSalary = await _context.EmployeeSalarys.FindAsync(id);
            _context.EmployeeSalarys.Remove(employeeSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeSalaryExists(int id)
        {
            return _context.EmployeeSalarys.Any(e => e.EmployeeSalaryId == id);
        }
    }
}
