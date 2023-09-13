using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApproachLibrary.DataAccess
{
    public class NguoiDungDao
    {
        private static NguoiDungDao instance = null;
        private static readonly object instanceLock = new object();
        public static NguoiDungDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NguoiDungDao();
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

        public IEnumerable<NguoiDung> GetNguoiDungList(string sortBy)
        {
            ///ham sort by name 
            using var context = new MyStockContext();
            List<NguoiDung> model = context.NguoiDungs.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenDangNhap).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenDangNhap).ToList();
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
        #endregion
    }
}
