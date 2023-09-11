using DemoApproachLibrary.DataAccess;
using DemoApproachLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using X.PagedList;

namespace MyCodeFirstApprochDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffController : Controller
    {
        INhanVienRepository nhanVienRepository = null;
        public StaffController() => nhanVienRepository = new NhanVienRepository();
        // GET: StaffController
        public ActionResult Index(string searchString, int? page, string sortBy)
        {
            var nhanVienList = nhanVienRepository.GetNhanViens(sortBy).ToPagedList(page ?? 1, 5);
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                nhanVienList = nhanVienRepository.GetNhanVienByName(searchString, sortBy).ToPagedList(page ?? 1, 5);
            }
            /*  TempData["searchString"] = searchString;*/
            return View(nhanVienList);
        }

        // GET: StaffController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien kh)
        {
            try
            {
                nhanVienRepository.InsertNhanVien(kh);
                TempData["Message"] = "Tạo mới thành công";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            var kh = nhanVienRepository.GetNhanVienByID(id);
            return View(kh);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NhanVien kh)
        {
            try
            {
                nhanVienRepository.UpdateNhanVien(kh);
                TempData["Message"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                nhanVienRepository.DeleteNhanVien(id);
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
            nhanVienRepository.DeleteSelectedNhanVien(SelectedCatDelete);
            TempData["Message"] = $"Xoá {SelectedCatDelete.Count()} hàng thành công";
            return RedirectToAction("Index");
        }
    }
}
