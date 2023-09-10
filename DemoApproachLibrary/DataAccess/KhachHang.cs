using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DemoApproachLibrary.DataAccess
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }
        [Display(Name = "Mã khách hàng")]
        public int MaKhachHang { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string? TenKhachHang { get; set; }
        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        public string? DienThoai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
