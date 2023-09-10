using System;
using System.Collections.Generic;

namespace DemoApproachLibrary.DataAccess
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int MaHoaDon { get; set; }
        public int MaNhanVien { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime NgayBan { get; set; }
        public decimal TongTien { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
        public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
