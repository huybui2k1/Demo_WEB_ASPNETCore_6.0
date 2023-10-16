using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCodeFirstApprochDemo.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    [Authorize(AuthenticationSchemes = "User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
