using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApproachLibrary.DataAccess
{
    public class NhanVienDao
    {
        private static NhanVienDao instance = null;
        private static readonly object instanceLock = new object();
        public static NhanVienDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NhanVienDao();
                    }
                    return instance;
                }
            }
        }

        #region Tìm kiếm , so sánh 
        /// <summary>
        /// Chức nawngL Hiển thị tất cả thông tin của khách hàng , kết hợp sắp xếp theo tên
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public IEnumerable<NhanVien> GetNhanVienList(string sortBy)
        {
            ///ham sort by name 
            using var context = new MyStockContext();
            List<NhanVien> model = context.NhanViens.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenNhanVien).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenNhanVien).ToList();
                        break;
                    case "address":
                        model = model.OrderBy(o => o.DiaChi).ToList();
                        break;
                    case "addressdesc":
                        model = model.OrderByDescending(o => o.DiaChi).ToList();
                        break;
                    case "id":
                        model = model.OrderBy(o => o.MaNhanVien).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaNhanVien).ToList();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }

        public NhanVien GetNhanVienByID(int id)
        {
            NhanVien kh = null;
            try
            {
                using var context = new MyStockContext();
                kh = context.NhanViens.SingleOrDefault(k => k.MaNhanVien == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return kh;
        }

        public IEnumerable<NhanVien> GetNhanVienBySearchName(string name, string sortBy)
        {

            //ham sort by name  
            var context = new MyStockContext();
            /*var khachHangs = new List<KhachHang>();*/
            List<NhanVien> model = context.NhanViens.ToList();

            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.TenNhanVien.ToLower().Contains(name)).ToList();
                    switch (sortBy)
                    {
                        case "name":
                            model = model.OrderBy(o => o.TenNhanVien).ToList();
                            break;
                        case "namedesc":
                            model = model.OrderByDescending(o => o.TenNhanVien).ToList();
                            break;
                        case "address":
                            model = model.OrderBy(o => o.DiaChi).ToList();
                            break;
                        case "addressdesc":
                            model = model.OrderByDescending(o => o.DiaChi).ToList();
                            break;
                        case "id":
                            model = model.OrderBy(o => o.MaNhanVien).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.MaNhanVien).ToList();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }

        #endregion
        public void AddNew(NhanVien kh)
        {

            try
            {
                NhanVien _kh = GetNhanVienByID(kh.MaNhanVien);
                if (_kh == null)
                {
                    using var context = new MyStockContext();
                    context.NhanViens.Add(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(NhanVien kh)
        {

            try
            {
                NhanVien _kh = GetNhanVienByID(kh.MaNhanVien);
                if (_kh != null)
                {
                    using var context = new MyStockContext();
                    context.NhanViens.Update(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                NhanVien _kh = GetNhanVienByID(id);
                if (_kh != null)
                {
                    using var context = new MyStockContext();
                    context.NhanViens.Remove(_kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NhanVien> RemoveNhanVienSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyStockContext();
            var DeleteCatList = context.NhanViens.Where(z => DeleteList.Contains(z.MaNhanVien)).ToList();
            context.NhanViens.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }
    }
}
