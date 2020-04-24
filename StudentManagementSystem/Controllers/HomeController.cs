using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            try
            {
                if (email != null && password != null)
                {
                    var finduser = _context.Users.Where(u => u.Email == email && u.Password == password).ToList();
                    if (finduser.Count() == 1)
                    {
                        HttpContext.Session.SetString("UserId", finduser[0].UserId.ToString());
                        HttpContext.Session.SetString("UserTypeId", finduser[0].UserTypeId.ToString());
                        HttpContext.Session.SetString("FullName", finduser[0].FullName.ToString());
                        HttpContext.Session.SetString("UserName", finduser[0].UserName.ToString());
                        HttpContext.Session.SetString("Password", finduser[0].Password.ToString());
                        HttpContext.Session.SetString("ContactNo", finduser[0].ContactNo.ToString());
                        HttpContext.Session.SetString("Email", finduser[0].Email.ToString());
                        HttpContext.Session.SetString("Address", finduser[0].Address.ToString());

                        UserType userType = _context.UserTypes.Find(finduser[0].UserTypeId);
                        if(userType.TypeName != null)
                        {
                            HttpContext.Session.SetString("UserType", userType.TypeName.ToString());
                        }

                        var student = _context.Students.Where(s => s.Email == finduser[0].UserName).FirstOrDefault();
                        if (student != null)
                        {
                            HttpContext.Session.SetString("Photo", student.Photo.ToString());
                        }
                        else
                        {
                            var employee = _context.Staffs.Where(e => e.Email == finduser[0].UserName).FirstOrDefault();
                            HttpContext.Session.SetString("Photo", employee.photo.ToString());
                        }


                        //UserTypeId UserTypeName
                        //1. Admin
                        //2. Operator
                        //3. Teacher
                        //4. Student

                        string url = string.Empty;
                        if (finduser[0].UserTypeId == 1)
                        {
                            return RedirectToAction("About");
                        }
                        if (finduser[0].UserTypeId == 2)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].UserTypeId == 3)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].UserTypeId == 4)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].UserTypeId == 5)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].UserTypeId == 6)
                        {
                            return RedirectToAction("About");
                        }
                        return RedirectToAction(url);
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserId", string.Empty);
                        HttpContext.Session.SetString("UserTypeId", string.Empty);
                        HttpContext.Session.SetString("FullName", string.Empty);
                        HttpContext.Session.SetString("UserName", string.Empty);
                        HttpContext.Session.SetString("Password", string.Empty);
                        HttpContext.Session.SetString("ContactNo", string.Empty);
                        HttpContext.Session.SetString("Email", string.Empty);
                        HttpContext.Session.SetString("Address", string.Empty);
                        ViewBag.message = "User Name and Password is incorrect!";
                    }
                }
                else
                {
                    HttpContext.Session.SetString("UserId", string.Empty);
                    HttpContext.Session.SetString("UserTypeId", string.Empty);
                    HttpContext.Session.SetString("FullName", string.Empty);
                    HttpContext.Session.SetString("UserName", string.Empty);
                    HttpContext.Session.SetString("Password", string.Empty);
                    HttpContext.Session.SetString("ContactNo", string.Empty);
                    HttpContext.Session.SetString("Email", string.Empty);
                    HttpContext.Session.SetString("Address", string.Empty);                    
                    ViewBag.message = "Some  unexpected issue occured.Please try again!";
                }
            }
            catch(Exception ex)
            {
                HttpContext.Session.SetString("UserId", string.Empty);
                HttpContext.Session.SetString("UserTypeId", string.Empty);
                HttpContext.Session.SetString("FullName", string.Empty);
                HttpContext.Session.SetString("UserName", string.Empty);
                HttpContext.Session.SetString("Password", string.Empty);
                HttpContext.Session.SetString("ContactNo", string.Empty);
                HttpContext.Session.SetString("Email", string.Empty);
                HttpContext.Session.SetString("Address", string.Empty);                
                ViewBag.message = "Some  unexpected issue occured.Please try again!";
            }
            return View("Login");
        }

        public IActionResult About()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = "Welcome to Praise-El Schools Management System";
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ViewBag.Message = "Password/Confirm Password Not Matched!";
                return View("ChangePassword");
            }
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var getUser = _context.Users.Find(userId);
            if (getUser.Password == oldPassword.Trim())
            {
                getUser.Password = newPassword.Trim();
                _context.Entry(getUser).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Message = "Old Password is Incorrect!";
                return View("ChangePassword");
            }            
            return RedirectToAction("Logout");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.SetString("UserId", string.Empty);
            HttpContext.Session.SetString("UserTypeId", string.Empty);
            HttpContext.Session.SetString("FullName", string.Empty);
            HttpContext.Session.SetString("UserName", string.Empty);
            HttpContext.Session.SetString("Password", string.Empty);
            HttpContext.Session.SetString("ContactNo", string.Empty);
            HttpContext.Session.SetString("Email", string.Empty);
            HttpContext.Session.SetString("Address", string.Empty);
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
