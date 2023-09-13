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
        [Display(Name = "Mã Nhân Viên")]
        public int MaNhanVien { get; set; }
        [Display(Name = "Tên Nhân Viên")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ tên Nhân Viên")]
        public string? TenNhanVien { get; set; }
        public bool GioiTinh { get; set; }
        [Display(Name = "Địa chỉ Nhân Viên")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ Địa chỉ Nhân Viên")]
        public string? DiaChi { get; set; }
        [Display(Name = "Địa thoại Nhân Viên")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ Điện thoại Nhân Viên")]
        public string? DienThoai { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ Ngày sinh Nhân Viên")]
        public DateTime NgaySinh { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
