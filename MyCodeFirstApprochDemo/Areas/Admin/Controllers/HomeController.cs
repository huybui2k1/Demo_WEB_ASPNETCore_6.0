using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace MyCodeFirstApprochDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class HomeController : Controller
    {
        /* private readonly ILogger<HomeController> _logger;*/

        /*  public HomeController(ILogger<HomeController> logger)
          {
              _logger = logger;
          }
         */
        
        public IActionResult Index()
        {
            /* var user = User as ClaimsPrincipal;
             var userName = user?.FindFirstValue(ClaimTypes.Name);
             ViewData["MessageInfo"] = userName;*/

            if (!string.IsNullOrEmpty(Request.Query["ReturnURL"])){

                return Redirect("" + Request.Query["ReturnURL"]);
            }
            return View();
        }
       
    }
}
