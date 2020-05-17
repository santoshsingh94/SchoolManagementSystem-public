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
using Microsoft.AspNetCore.Authorization;
using SchoolManagementSystem.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("About", "Home");
            }
            return View();
        }      
        public IActionResult About()
        {
            ViewBag.Message = "Welcome to Praise-El Schools Management System";
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
