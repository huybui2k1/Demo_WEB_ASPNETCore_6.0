using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoApproachLibrary.DataAccess
{
    public class NguoiDungViewModel
    {
        public string TenDangNhap { get; set; }
        public int LoaiNguoiDung { get; set; }
        [Display(Name = "Mã người dùng")]
        public string MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public bool GioiTinh { get; set; }
    }
}
