using System;
using System.Collections.Generic;

namespace DemoApproachLibrary.DataAccess
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int MaNhanVien { get; set; }
        public string? TenNhanVien { get; set; }
        public bool GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public DateTime NgaySinh { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
