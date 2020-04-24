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
    public class EventTblsController : Controller
    {
        private readonly AppDbContext _context;

        public EventTblsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventTbls
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var appDbContext = _context.Events.Include(e => e.User).OrderByDescending(e=>e.EventTblId);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EventTbls/Details/5
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

            var eventTbl = await _context.Events
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventTblId == id);
            if (eventTbl == null)
            {
                return NotFound();
            }

            return View(eventTbl);
        }

        // GET: EventTbls/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: EventTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventTblId,EventTitle,EventDate,Location,Description,UserId")] EventTbl eventTbl)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            eventTbl.UserId = userid;
            if (ModelState.IsValid)
            {
                _context.Add(eventTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", eventTbl.UserId);
            return View(eventTbl);
        }

        // GET: EventTbls/Edit/5
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

            var eventTbl = await _context.Events.FindAsync(id);
            if (eventTbl == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", eventTbl.UserId);
            return View(eventTbl);
        }

        // POST: EventTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  EventTbl eventTbl)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            eventTbl.UserId = userid;
            if (id != eventTbl.EventTblId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTblExists(eventTbl.EventTblId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", eventTbl.UserId);
            return View(eventTbl);
        }

        // GET: EventTbls/Delete/5
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

            var eventTbl = await _context.Events
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventTblId == id);
            if (eventTbl == null)
            {
                return NotFound();
            }

            return View(eventTbl);
        }

        // POST: EventTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var eventTbl = await _context.Events.FindAsync(id);
            _context.Events.Remove(eventTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTblExists(int id)
        {
            return _context.Events.Any(e => e.EventTblId == id);
        }
    }
}
