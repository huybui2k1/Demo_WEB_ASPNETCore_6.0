using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApproachLibrary.DataAccess
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }
        [Display(Name ="Mã Khách Hàng")]
        public int MaKhachHang { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        [Required(ErrorMessage ="Yêu cầu nhập đầy đủ tên khách hàng")]
        public string? TenKhachHang { get; set; }
        [Display(Name = "Địa chỉ Khách Hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ Địa chỉ khách hàng")]
        public string? DiaChi { get; set; }
        [Display(Name = "Địa thoại Khách Hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ Điện thoại khách hàng")]
        public string? DienThoai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
