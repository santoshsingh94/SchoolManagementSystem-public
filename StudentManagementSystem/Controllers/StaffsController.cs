using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.ViewModels;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class StaffsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public StaffsController(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var appDbContext = _context.Staffs.Include(s => s.Designation).Include(s => s.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Staffs/Details/5
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

            var staff = await _context.Staffs
                .Include(s => s.Designation)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( StaffViewModel staff)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));           
            ///////////Here every staff is an user, so we provide user Id behalf of user type(staff).x
            
            if (ModelState.IsValid)
            {
                var userType = _context.UserTypes.Where(u => u.TypeName == "Employee").FirstOrDefault();
                int userTypeId = 0;
                if (userType != null)
                {
                    userTypeId = userType.UserTypeId;
                }
                var user = new User()
                {
                    Address = staff.Address,
                    ContactNo = staff.ContactNo,
                    Email=staff.Email,
                    FullName=staff.Name,
                    UserName=staff.Email,
                    UserTypeId = userTypeId, //Check your Db To get usertypeid of Employeetype
                    Password="password" //default password for all the employee
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                string uniqueFileName = null;
                if(staff.photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    staff.photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Staff newStaff = new Staff
                {
                    UserId = userid,
                    Name = staff.Name,
                    DesignationId = staff.DesignationId,
                    ContactNo = staff.ContactNo,
                    BasicSalary = staff.BasicSalary,
                    Email = staff.Email,
                    Address = staff.Address,
                    Qualification = staff.Qualification,
                    photo = uniqueFileName,
                    Description = staff.Description,
                    IsActive = staff.IsActive,
                    Gender = staff.Gender,
                    HomePhone = staff.HomePhone,
                    DoYouHaveAnyDisability = staff.DoYouHaveAnyDisability,
                    DisabilityDetails = staff.DisabilityDetails,
                    TakingAnyMedication = staff.TakingAnyMedication,
                    MedicationDetails = staff.MedicationDetails,
                    AnyCriminalOffence = staff.AnyCriminalOffence,
                    CriminalOffenceDetails = staff.CriminalOffenceDetails,
                    RegistrationDate = DateTime.Now
                };                
                _context.Staffs.Add(newStaff);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("details", new { id = newStaff.StaffId });
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", staff.DesignationId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", staff.UserId);
            return View(staff);
        }

        // GET: Staffs/Edit/5
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

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "Title", staff.DesignationId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", staff.UserId);
            ViewData["Photo"] = staff.photo;
            StaffViewModel viewStaff = new StaffViewModel
            {
                StaffId = staff.StaffId,
                UserId = staff.UserId,
                Name = staff.Name,
                DesignationId = staff.DesignationId,
                ContactNo = staff.ContactNo,
                BasicSalary = staff.BasicSalary,
                Email = staff.Email,
                Address = staff.Address,
                Qualification = staff.Qualification,
                //Convert.ToString(photo) = staff.photo,
                Description = staff.Description,
                IsActive = staff.IsActive,
                Gender = staff.Gender,
                HomePhone = staff.HomePhone,
                DoYouHaveAnyDisability = staff.DoYouHaveAnyDisability,
                DisabilityDetails = staff.DisabilityDetails,
                TakingAnyMedication = staff.TakingAnyMedication,
                MedicationDetails = staff.MedicationDetails,
                AnyCriminalOffence = staff.AnyCriminalOffence,
                CriminalOffenceDetails = staff.CriminalOffenceDetails,
                RegistrationDate = staff.RegistrationDate
            };

            return View(viewStaff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StaffViewModel staff)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            staff.StaffId = id;
            staff.UserId = userid;
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (staff.photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    staff.photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Staff newStaff = new Staff
                {
                    StaffId = staff.StaffId,
                    UserId = userid,
                    Name = staff.Name,
                    DesignationId = staff.DesignationId,
                    ContactNo = staff.ContactNo,
                    BasicSalary = staff.BasicSalary,
                    Email = staff.Email,
                    Address = staff.Address,
                    Qualification = staff.Qualification,
                    photo = uniqueFileName,
                    Description = staff.Description,
                    IsActive = staff.IsActive,
                    Gender = staff.Gender,
                    HomePhone = staff.HomePhone,
                    DoYouHaveAnyDisability = staff.DoYouHaveAnyDisability,
                    DisabilityDetails = staff.DisabilityDetails,
                    TakingAnyMedication = staff.TakingAnyMedication,
                    MedicationDetails = staff.MedicationDetails,
                    AnyCriminalOffence = staff.AnyCriminalOffence,
                    CriminalOffenceDetails = staff.CriminalOffenceDetails,
                    RegistrationDate = DateTime.Now
                };
                try
                {
                    _context.Update(newStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
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
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationId", staff.DesignationId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", staff.UserId);
            return View(staff);
        }

        //GET: Staffs/Delete/5
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

            var staff = await _context.Staffs
                .Include(s => s.Designation)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        //POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]      
        public async Task<IActionResult> Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            var staff = await _context.Staffs.FindAsync(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
