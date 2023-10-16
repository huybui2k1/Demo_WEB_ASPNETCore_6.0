using DemoApproachLibrary.Common;
using DemoApproachLibrary.DataAccess;
using DemoApproachLibrary.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Globalization;
using X.PagedList;

namespace MyCodeFirstApprochDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductController : BaseController
    {
        IProductRepository productRepository = null;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            productRepository = new ProductRepository();
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: ProductController
        public ActionResult Index(string searchString, int? page, string sortBy)
        {
           /* MailUtils.SendMailGoogleSmtp("sfdgdgdgdfg@gmail.com", "1911504410119@sv.ute.udn.vn", "Xin chào", "Nội dung nè", "sfdgdgdgdfg@gmail.com", "kscxffulrsoizrjo");*/
            var productList = productRepository.GetProductByName(searchString is null ? null : searchString.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
            return View(productList);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HangHoa hh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = UploadedFile(hh);
                    hh.Anh = uniqueFileName;
                    productRepository.InsertProduct(hh);
                    SetAlert("Tạo mới thành công", "error");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới khách hàng không thành công");
                }
            }
            catch
            {

            }
            return View(hh);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private string UploadedFile(HangHoa hh)
        {
            //string uniqueFileName = UploadedFile(hh);
            //Save image to wwwroot/image
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(hh.ImageFile.FileName);
            string extension = Path.GetExtension(hh.ImageFile.FileName);
            hh.Anh = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Upload/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                hh.ImageFile.CopyTo(fileStream);
            }
            ViewBag.Anh = hh.Anh;
            return fileName;
        }

    }
}
