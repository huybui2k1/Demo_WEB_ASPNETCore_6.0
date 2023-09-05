using Microsoft.AspNetCore.Mvc;
using MyCodeFirstApprochDemo.Models;

namespace MyCodeFirstApprochDemo.Controllers
{
    public class RegisterController1 : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");

            }
            else
            {
                return View(model);

            }
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
