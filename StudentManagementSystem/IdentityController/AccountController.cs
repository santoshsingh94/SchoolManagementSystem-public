using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Identity;

namespace SchoolManagementSystem.IdentityController
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            var isUserCreated = await userManager.Users.FirstOrDefaultAsync();
            if (isUserCreated != null)
            {
                ModelState.AddModelError("isUserCreated", "Admin User Already Exist!! Please Login");
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [AcceptVerbs("get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already taken");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, City = model.City };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("about", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var isUserCreated =await userManager.Users.FirstOrDefaultAsync();
            if(isUserCreated !=null)
            {
                HttpContext.Session.SetString("isUserCreated", "true");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);                
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                        //return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ApplicationUser user = userManager.Users.Where(u => u.Email == model.Email).FirstOrDefault();
                        if(user!=null)
                        {
                            var roles = roleManager.Roles;
                            foreach (var role in roles)
                            {
                                var exist = await userManager.IsInRoleAsync(user, role.Name);
                                if(exist)
                                {
                                    HttpContext.Session.SetString("Role", role.Name);
                                    break;
                                }
                            }
                            //HttpContext.Session.SetString("UserName", user.UserName);
                        }
                        if (user.Image != null)
                        {
                            HttpContext.Session.SetString("Photo", user.Image);
                        }
                        return RedirectToAction("About", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }

            return View(model);
        }
        public async Task<IActionResult> ListRoles()
        {
            List<EditRoleViewModel> listRoles = new List<EditRoleViewModel>();
            List<EditRoleViewModel> viewModel = new List<EditRoleViewModel>();
            var roles = roleManager.Roles;
            foreach (var item in roles)
            {
                var roleModel = new EditRoleViewModel
                {
                    Id = item.Id,
                    RoleName = item.Name
                };
                listRoles.Add(roleModel);
            }

            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var item in userManager.Users)
            {
                users.Add(item);
            }


            foreach (var role in listRoles)
            {
                EditRoleViewModel model = new EditRoleViewModel();
                model.Id = role.Id;
                model.RoleName = role.RoleName;
                foreach (var user in users)
                {
                    var exist = await userManager.IsInRoleAsync(user, role.RoleName);
                    if (exist)
                    {
                        model.Users.Add(user.UserName);
                    }
                }
                viewModel.Add(model);
            }
            return View(viewModel);
        }

        public async Task<IActionResult> ListUsers()
        {
            var users =userManager.Users;
            return View(users);
        }

       public IActionResult AccessDenied()
        {
            //return RedirectToPage("Error.cshtml");
            return View();
        }
    }
}



