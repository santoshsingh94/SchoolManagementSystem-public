using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using SchoolManagementSystem.ViewModels;
using StudentManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentsController(AppDbContext context, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }
        //Finding Application User
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Students

        [HttpGet]
        public async Task<IActionResult> Index()
        {           
            var appDbContext = _context.Students
                .Include(s => s.ClassTbl)
                .Include(s => s.Programe)
                .Include(s => s.Session)
                .Include(s => s.ApplicationUser)
                .OrderByDescending(s=>s.StudentId);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.ClassTbl)
                .Include(s => s.Programe)
                .Include(s => s.Session)
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name");
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "Name");
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderType");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "NationalityId", "NationalityType");
            ViewData["ReligionId"] = new SelectList(_context.Religions, "ReligionId", "ReligionType");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryType");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            ApplicationUser user =await GetCurrentUserAsync(); 
            if (ModelState.IsValid)
            {
                //Make the student a studentType User
                try
                {
                    //var userType = _context.UserTypes.Where(u => u.TypeName == "Student").FirstOrDefault();
                    //int userTypeId = 0;
                    //if (userType != null)
                    //{
                    //    userTypeId = userType.UserTypeId;
                    //}

                    //var user = new User()
                    //{
                    //    Address = model.Address,
                    //    ContactNo = model.ContactNo,
                    //    Email = model.Email,
                    //    FullName = model.Name,
                    //    UserName = model.Email,
                    //    UserTypeId = userTypeId, //Check your Db To get usertypeid of Employeetype
                    //    Password = "password" //default password for all the employee
                    //};
                    //_context.Users.Add(user);
                    //await _context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    return View();
                }

                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Student student = new Student
                {
                    ApplicationUserId = user?.Id,
                    SessionId = model.SessionId,
                    ProgrameId = model.ProgrameId,
                    ClassTblId = model.ClassTblId,
                    Name = model.Name,
                    FatherName = model.FatherName,
                    DateOfBirth = model.DateOfBirth,
                    GenderId = model.GenderId,
                    ContactNo = model.ContactNo,
                    Email = model.Email,
                    NationalityId = model.NationalityId,
                    ReligionId = model.ReligionId,
                    CategoryId = model.CategoryId,
                    Cast = model.Cast,
                    GuardianName = model.GuardianName,
                    GuardianOccupation = model.GuardianOccupation,
                    GuardianPhone = model.GuardianPhone,
                    Address = model.Address,
                    AadharNo = model.AadharNo,
                    Photo = uniqueFileName,
                    AdmissionDate = model.AdmissionDate,
                    PreviousSchool = model.PreviousSchool,
                    PreviousPercentage = model.PreviousPercentage
                };

                _context.Add(student);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("details", new { id = student.StudentId });
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", model.ClassTblId);
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "Name", model.ProgrameId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "Name", model.SessionId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "GenderId", "GenderType");
            ViewData["NationalityId"] = new SelectList(_context.Genders, "NationalityId", "NationalityType");
            ViewData["ReligionId"] = new SelectList(_context.Genders, "ReligionId", "ReligionType");
            ViewData["CategoryId"] = new SelectList(_context.Genders, "CategoryId", "CategoryType");
            return View(model);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "Name", student.ClassTblId);
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "Name", student.ProgrameId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "Name", student.SessionId);
            ViewData["Photo"] = student.Photo;
            StudentViewModel viewStudent = new StudentViewModel()
            {
                Name = student.Name,
                SessionId = student.SessionId,
                ProgrameId=student.ProgrameId,
                ClassTblId=student.ClassTblId,
                ApplicationUserId = user?.Id,
                FatherName=student.FatherName,
                DateOfBirth=student.DateOfBirth,
                GenderId=student.GenderId,
                ContactNo=student.ContactNo,
                Email=student.Email,
                NationalityId=student.NationalityId,
                ReligionId=student.ReligionId,
                CategoryId=student.CategoryId,
                Cast=student.Cast,
                GuardianName=student.GuardianName,
                GuardianOccupation=student.GuardianOccupation,
                GuardianPhone=student.GuardianPhone,
                Address=student.Address,
                AadharNo=student.AadharNo,
                AdmissionDate=student.AdmissionDate,
                PreviousPercentage=student.PreviousPercentage,
                PreviousSchool=student.PreviousSchool
            };

            return View(viewStudent);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentViewModel model)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            model.ApplicationUserId = user?.Id;
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Student student = new Student()
                {
                    StudentId=id,
                    Name = model.Name,
                    SessionId = model.SessionId,
                    ProgrameId = model.ProgrameId,
                    ClassTblId = model.ClassTblId,
                    ApplicationUserId = model.ApplicationUserId,
                    FatherName = model.FatherName,
                    DateOfBirth = model.DateOfBirth,
                    GenderId = model.GenderId,
                    ContactNo = model.ContactNo,
                    Email = model.Email,
                    NationalityId = model.NationalityId,
                    ReligionId = model.ReligionId,
                    CategoryId = model.CategoryId,
                    Cast = model.Cast,
                    Photo=uniqueFileName,
                    GuardianName = model.GuardianName,
                    GuardianOccupation = model.GuardianOccupation,
                    GuardianPhone = model.GuardianPhone,
                    Address = model.Address,
                    AadharNo = model.AadharNo,
                    AdmissionDate = model.AdmissionDate,
                    PreviousPercentage = model.PreviousPercentage,
                    PreviousSchool = model.PreviousSchool
                };
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["ClassTblId"] = new SelectList(_context.ClassTbls, "ClassTblId", "ClassTblId", model.ClassTblId);
            ViewData["ProgrameId"] = new SelectList(_context.Programes, "ProgrameId", "ProgrameId", model.ProgrameId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "SessionId", "SessionId", model.SessionId);
            return View(model);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.ClassTbl)
                .Include(s => s.Programe)
                .Include(s => s.Session)
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [Authorize(Roles = "Admin,Operator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
