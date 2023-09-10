using System;
using System.Collections.Generic;

namespace DemoApproachLibrary.DataAccess
{
    public partial class ChiTietHoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaHangHoa { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? GiamGia { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual HangHoa MaHangHoaNavigation { get; set; } = null!;
        public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
    }
}
