using Microsoft.AspNetCore.Mvc;

namespace MyCodeFirstApprochDemo.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected void SetAlert(string message , string type)
        {
            TempData["AlertMessage"] = message;
            if(type== "success")
            {
                TempData["AlertType"] = "alert-success";

            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
       
    }
}
