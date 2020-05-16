using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class ExpenseReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ExpenseReportsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult AllExpenses()
        {
            var allExpense = _context.Expenses
                .Include(e=>e.ExpenseType)
                .Include(u=>u.ApplicationUser).ToList()
                .OrderByDescending(e => e.ExpenseId);
            return View(allExpense);
        }
        [HttpGet]
        public IActionResult CustomExpenses()
        {
            var allExpense = _context.Expenses
                .Where(e => e.ExpensesDate >= DateTime.Now && e.ExpensesDate <= DateTime.Now)
                .Include(e => e.ExpenseType)
                .Include(u => u.ApplicationUser).ToList()
                .OrderByDescending(e => e.ExpenseId);
            return View(allExpense);
        }
        [HttpPost]
        public IActionResult CustomExpenses(DateTime fromDate, DateTime toDate)
        {
            var allExpense = _context.Expenses
                .Where(e=>e.ExpensesDate >= fromDate && e.ExpensesDate<=toDate)
                .Include(e => e.ExpenseType)
                .Include(u => u.ApplicationUser).ToList()
                .OrderByDescending(e => e.ExpenseId);
            return View(allExpense);
        }
    }
}