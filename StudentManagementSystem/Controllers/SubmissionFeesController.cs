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
    public class SubmissionFeesController : Controller
    {
        private readonly AppDbContext _context;

        public SubmissionFeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SubmissionFees
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            var appDbContext = _context.SubmissionFees.Include(s => s.ClassTbl)
                .Include(s => s.Programe)
                .Include(s => s.Student)
                .Include(s => s.User)
                .OrderByDescending(s=>s.SubmissionFeeId); 
            return View(await appDbContext.ToListAsync());
        }

        //Ajax call 
        public ActionResult GetByPromoteId(string sid)
        {
            if (sid != null)
            {
                int promoteId = Convert.ToInt32(sid);
                var promoteRecord = _context.StudentPromotes.Find(promoteId);
                if (promoteRecord != null)
                {
                    var StudentId = promoteRecord.StudentId;
                    var ClassId = promoteRecord.ClassTblId;
                    var gettingPrograme = _context.ProgrameSessions.Find(promoteRecord.ProgrameSessionId);
                    var ProgrameId = gettingPrograme.ProgrameId;
                    return Json(new { StudentId, ClassId, ProgrameId });
                }
                else
                {
                    ViewBag.Message = "PromoteId does not exist!!";
                    return null;
                }
            }
            return null;
        }

        // GET: SubmissionFees/Details/5
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

            var submissionFee = await _context.SubmissionFees
                .Include(s => s.ClassTbl)
                .Include(s => s.Programe)
                .Include(s => s.Student)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SubmissionFeeId == id);
            if (submissionFee == null)
            {
                return NotFound();
            }

            return View(submissionFee);
        }

        // GET: SubmissionFees/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name");
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: SubmissionFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubmissionFee submissionFee)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            submissionFee.UserId = userid;

            if (ModelState.IsValid)
            {
                _context.Add(submissionFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", submissionFee.ClassTblId);
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "Name", submissionFee.ProgrameId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name", submissionFee.StudentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", submissionFee.UserId);
            return View(submissionFee);
        }

        // GET: SubmissionFees/Edit/5
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

            var submissionFee = await _context.SubmissionFees.FindAsync(id);
            if (submissionFee == null)
            {
                return NotFound();
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", submissionFee.ClassTblId);
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "Name", submissionFee.ProgrameId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "Name", submissionFee.StudentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name", submissionFee.UserId);
            return View(submissionFee);
        }

        // POST: SubmissionFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubmissionFee submissionFee)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            submissionFee.UserId = userid;

            if (id != submissionFee.SubmissionFeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submissionFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmissionFeeExists(submissionFee.SubmissionFeeId))
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
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "ClassTblId", submissionFee.ClassTblId);
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "ProgrameId", submissionFee.ProgrameId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", submissionFee.StudentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", submissionFee.UserId);
            return View(submissionFee);
        }

        // GET: SubmissionFees/Delete/5
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

            var submissionFee = await _context.SubmissionFees
                .Include(s => s.ClassTbl)
                .Include(s => s.Programe)
                .Include(s => s.Student)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SubmissionFeeId == id);
            if (submissionFee == null)
            {
                return NotFound();
            }

            return View(submissionFee);
        }

        // POST: SubmissionFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }

            var submissionFee = await _context.SubmissionFees.FindAsync(id);
            _context.SubmissionFees.Remove(submissionFee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmissionFeeExists(int id)
        {
            return _context.SubmissionFees.Any(e => e.SubmissionFeeId == id);
        }
    }
}
