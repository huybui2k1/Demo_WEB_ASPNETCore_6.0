using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCodeFirstApprochDemo.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
