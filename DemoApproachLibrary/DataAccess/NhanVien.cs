using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DemoApproachLibrary.DataAccess
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }
        [Display(Name = "Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [Display(Name = "Tên Nhân Viên")]
        public string? TenNhanVien { get; set; }
        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; }
        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        public string? DienThoai { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
