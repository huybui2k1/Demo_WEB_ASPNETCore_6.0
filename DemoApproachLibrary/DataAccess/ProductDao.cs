using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApproachLibrary.DataAccess
{
    public class ProductDao
    {
        private static ProductDao instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDao();
                    }
                    return instance;
                }
            }
        }
        #region Tìm kiếm, so sánh

        /// <summary>
        /// Chức năng: Hiển thị tất cả thông tin của hàng hoá, kết hợp sắp xếp theo tên
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<HangHoa> GetProductList(string sortBy)
        {
            using var context = new MyStockContext();
            List<HangHoa> model = context.HangHoas.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenHangHoa).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenHangHoa).ToList();
                        break;
                    case "id":
                        model = model.OrderBy(o => o.MaHangHoa).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaHangHoa).ToList();
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

        public HangHoa GetProductByID(int id)
        {
            HangHoa hh = null;
            try
            {
                using var context = new MyStockContext();
                hh = context.HangHoas.SingleOrDefault(k => k.MaHangHoa == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return hh;
        }



        public IEnumerable<HangHoa> GetProductBySearchName(string name, string sortBy)
        {
            var context = new MyStockContext();
            /*var khachHangs = new List<KhachHang>();*/
            List<HangHoa> model = context.HangHoas.ToList();

            try
            {
                /* if (!String.IsNullOrEmpty(name))
                 {*/
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.TenHangHoa.ToLower().Contains(name)).ToList();
                }
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenHangHoa).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenHangHoa).ToList();
                        break;
                    case "id":
                        model = model.OrderBy(o => o.MaHangHoa).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaHangHoa).ToList();
                        break;
                    default:
                        break;
                }
                /*}*/
                /*else
                {
                    return model;
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }
        #endregion


        public void AddNew(HangHoa hh)
        {

            try
            {
                HangHoa _hh = GetProductByID(hh.MaHangHoa);
                if (_hh == null)
                {
                    using var context = new MyStockContext();
                    context.HangHoas.Add(hh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(HangHoa hh)
        {

            try
            {
                HangHoa _hh = GetProductByID(hh.MaHangHoa);
                if (_hh != null)
                {
                    using var context = new MyStockContext();
                    context.HangHoas.Update(hh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not already exist.");
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
                HangHoa _hh = GetProductByID(id);
                if (_hh != null)
                {
                    using var context = new MyStockContext();
                    context.HangHoas.Remove(_hh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
