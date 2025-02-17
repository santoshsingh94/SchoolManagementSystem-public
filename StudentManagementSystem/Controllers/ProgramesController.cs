﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class ProgramesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProgramesController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Programes
        public async Task<IActionResult> Index()
        {           
            var appDbContext = _context.Programes.Include(p => p.ApplicationUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Programes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var programe = await _context.Programes
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProgrameId == id);
            if (programe == null)
            {
                return NotFound();
            }

            return View(programe);
        }

        // GET: Programes/Create
        public IActionResult Create()
        {           
            return View();
        }

        // POST: Programes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Programe programe)
        {
            var model = _context.Programes.Where(s => s.Name.Trim() == programe.Name.Trim()).FirstOrDefault();
            if (model == null)
            {
                var user = await GetCurrentUserAsync();
                programe.ApplicationUserId = user?.Id;
                if (ModelState.IsValid)
                {
                    _context.Add(programe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError(string.Empty, "Programe already exists.");
            return View(programe);
        }

        // GET: Programes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programe = await _context.Programes.FindAsync(id);
            if (programe == null)
            {
                return NotFound();
            }
            return View(programe);
        }

        // POST: Programes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Programe programe)
        {
            if (id != programe.ProgrameId)
            {
                return NotFound();
            }
            var result = _context.Programes.Where(s => s.Name.Trim() == programe.Name.Trim() && s.ProgrameId != id).ToList();
            if (result.Count == 0)
            {
                var user = await GetCurrentUserAsync();
                programe.ApplicationUserId = user?.Id;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(programe);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProgrameExists(programe.ProgrameId))
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
            }
            ModelState.AddModelError(string.Empty, "Programe already exists.");
            return View(programe);
        }

        // GET: Programes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var programe = await _context.Programes
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ProgrameId == id);
            if (programe == null)
            {
                return NotFound();
            }

            return View(programe);
        }

        // POST: Programes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programe = await _context.Programes.FindAsync(id);
            _context.Programes.Remove(programe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrameExists(int id)
        {
            return _context.Programes.Any(e => e.ProgrameId == id);
        }
    }
}
