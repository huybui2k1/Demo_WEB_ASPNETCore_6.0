using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MyCodeFirstApprochDemo.Models;

namespace MyCodeFirstApprochDemo.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IActionResult Login(string ReturnUrl = "")
        {
            ViewData["Title"] = "Đăng nhập";
            LoginModel model = new LoginModel();
            model.UserName = "admin";
            model.Password = "12345";
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Đăng nhập";
            return View("Login");
        }

        public async Task<IActionResult> Logout()
        {

            // Đăng xuất người dùng
            await HttpContext.SignOutAsync();

            // Chuyển hướng đến trang đăng nhập hoặc trang chính
            return RedirectToAction("Index", "Account"); // Thay thế bằng tên trang đăng nhập hoặc trang chính của bạn
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
                if (!(username.Contains("admin") && password.Contains("12345")))
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
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = model.RememberLogin
                });
                TempData["Message"] = "Đăng nhập thành công";
                return RedirectToAction("Index", "Home");

                /*  ClaimsIdentity identity = null;
                  bool isAuthenticate = false;
                  if (username == "admin" && password == "admin")
                  {
                      identity = new ClaimsIdentity(new[]
                      {
                      new Claim(ClaimTypes.Name,username),
                      new Claim(ClaimTypes.Role,"Admin")
                  }, CookieAuthenticationDefaults.AuthenticationScheme);
                      isAuthenticate = true;
                  }
                  if (username == "demo" && password == "demo")
                  {
                      identity = new ClaimsIdentity(new[]
                      {
                      new Claim(ClaimTypes.Name,username),
                      new Claim(ClaimTypes.Role,"User")
                  }, CookieAuthenticationDefaults.AuthenticationScheme);
                      isAuthenticate = true;
                  }
                  if (isAuthenticate)
                  {
                      var principal = new ClaimsPrincipal(identity);
                      var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                      return RedirectToAction("Index", "Home");
                  }*/
            }
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View(model);
        }
    
}
}
