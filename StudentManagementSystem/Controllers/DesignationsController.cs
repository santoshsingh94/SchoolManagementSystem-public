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
    public class DesignationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public DesignationsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        // GET: Designations
        public async Task<IActionResult> Index()
        {
            
            var appDbContext = _context.Designations.Include(d => d.ApplicationUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Designations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var designation = await _context.Designations
                .Include(d => d.ApplicationUser)
                .FirstOrDefaultAsync(m => m.DesignationId == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // GET: Designations/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for  
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesignationId,UserId,Title,IsActive")] Designation designation)
        {
            var model = _context.Designations.Where(s => s.Title.Trim() == designation.Title.Trim()).FirstOrDefault();
            if (model == null)
            {
                var user = await GetCurrentUserAsync();
                designation.ApplicationUserId = user?.Id;

                if (ModelState.IsValid)
                {
                    _context.Add(designation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError(string.Empty, "Designation already exists.");
            return View(designation);
        }

        // GET: Designations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var designation = await _context.Designations.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }
            
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesignationId,UserId,Title,IsActive")] Designation designation)
        {
            
            if (id != designation.DesignationId)
            {
                return NotFound();
            }

            var result = _context.Designations.Where(s => s.Title == designation.Title && s.DesignationId != id).ToList();
            if (result.Count == 0)
            {
                var user = await GetCurrentUserAsync();
                designation.ApplicationUserId = user?.Id;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(designation);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DesignationExists(designation.DesignationId))
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
            ModelState.AddModelError(string.Empty, "Designation already exists.");
            return View(designation);
        }

        // GET: Designations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var designation = await _context.Designations
                .Include(d => d.ApplicationUser)
                .FirstOrDefaultAsync(m => m.DesignationId == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var designation = await _context.Designations.FindAsync(id);
            _context.Designations.Remove(designation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationExists(int id)
        {
            return _context.Designations.Any(e => e.DesignationId == id);
        }
    }
}
