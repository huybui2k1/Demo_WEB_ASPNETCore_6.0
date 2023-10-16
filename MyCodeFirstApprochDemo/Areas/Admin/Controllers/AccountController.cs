using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCodeFirstApprochDemo.Models;
using System.Security.Claims;

namespace MyCodeFirstApprochDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Đăng nhập";
            return RedirectToAction("Login", "Account", new { Areas = "Admin" });
        }
        public IActionResult Login()
        {
            ViewData["Title"] = "Đăng nhập";
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var username = model.UserName;
                var password = model.Password;
                if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
                {
                    return RedirectToAction("Login");
                }
                if (!(username.Contains("admin") && password.Contains("admin")))
                {
                    //TempData["Error"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                    return View(model);
                }
                //A claim is a statement about a subject by an issuer and    
                //represent attributes of the subject that are useful in the context of authentication and authorization operations.
                var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "Admin"),
                    };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, "Admin");
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync("Admin", principal, new AuthenticationProperties()
                {
                    IsPersistent = model.RememberLogin
                });
                TempData["Message"] = "Đăng nhập thành công";
                var routeValues = new RouteValueDictionary
                {
                    {"area","Admin" },
                    /*  {"claimType","AdminClaim" },*/
                    { "returnURL",Request.Query["ReturnURL"]},
                    {"claimValue","true" }
                };
                return RedirectToAction("Index", "Home", routeValues);// RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {

            // Đăng xuất người dùng
            await HttpContext.SignOutAsync("Admin");

            // Chuyển hướng đến trang đăng nhập hoặc trang chính
            return RedirectToAction("Login", "Account", new { Area = "Admin" }); // Thay thế bằng tên trang đăng nhập hoặc trang chính của bạn
        }
    }
}
