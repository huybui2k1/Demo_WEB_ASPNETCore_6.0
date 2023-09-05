using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyCodeFirstApprochDemo.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MyCodeFirstApprochDemo.Controllers
{
    [Authorize(Roles = "Admin")]
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var user = User as ClaimsPrincipal;
            var userName = user?.FindFirstValue(ClaimTypes.Name);
            ViewData["MessageInfo"] = userName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}