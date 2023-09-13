using DemoApproachLibrary.DataAccess;
using DemoApproachLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace MyCodeFirstApprochDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        IKhachHangRepository khachHangRepository = null;
        public CustomerController() => khachHangRepository = new KhachHangRepository();
        // GET: CustomerController
        [HttpGet]
        public ActionResult Index(string searchString, string CityName,int? page,string sortBy)
        {
            /*var khachHangList = khachHangRepository.GetKhachHangs(sortBy).ToPagedList(page ?? 1, 5);
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                khachHangList = khachHangRepository.GetKhachHangByName(searchString,sortBy).ToPagedList(page ?? 1, 5);
            }*/
            /*  TempData["searchString"] = searchString;*/

            var khachHangList = khachHangRepository.GetKhachHangByName(searchString is null ? null : searchString, CityName is null ? null : CityName.ToLower(), sortBy).ToPagedList(page ?? 1, 5);

            //Hiển thị thành phố
            var citys = new List<SelectListItem>
            {
                new SelectListItem{Value = "1", Text ="Đà Nẵng"},
                new SelectListItem{Value = "2", Text ="Huế"},
                new SelectListItem{Value = "3", Text ="Quảng Bình"}
               
            };
            ViewBag.City = citys;
            return View(khachHangList);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
       /* [ValidateAntiForgeryToken]*/
        public ActionResult Create(KhachHang kh)
        {
            try
            {
                khachHangRepository.InsertKhachHang(kh);
                TempData["Message"] = "Tạo mới thành công";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var kh = khachHangRepository.GetKhachHangByID(id);
            return View(kh);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KhachHang kh)
        {
            try
            {
                khachHangRepository.UpdateKhachHang(kh);
                TempData["Message"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                khachHangRepository.DeleteKhachHang(id);
                TempData["Message"] = "Xoá thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult DeleteMultiple(IEnumerable<int> SelectedCatDelete)
        {
            khachHangRepository.DeleteSelectedKhachHang(SelectedCatDelete);
            TempData["Message"] = $"Xoá {SelectedCatDelete.Count()} hàng thành công";
            return RedirectToAction("Index");
        }
    }
}
