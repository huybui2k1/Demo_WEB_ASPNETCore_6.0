using System;
using System.Collections.Generic;

namespace DemoApproachLibrary.DataAccess
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int MaHangHoa { get; set; }
        public string? TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal? DonGiaNhap { get; set; }
        public decimal? DonGiaBan { get; set; }
        public string? Anh { get; set; }
        public string? GhiChu { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
