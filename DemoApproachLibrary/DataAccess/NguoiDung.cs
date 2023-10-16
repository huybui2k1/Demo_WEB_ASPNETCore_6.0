using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApproachLibrary.DataAccess
{
    public partial class NguoiDung
    {
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ tên đăng nhập")]
        public string TenDangNhap { get; set; } = null!;
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ mật khẩu")]
        public string MatKhau { get; set; } = null!;
        [Required(ErrorMessage = "Yêu cầu chọn loại người dùng")]
        public int LoaiNguoiDung { get; set; }
        public int? MaNguoiDung { get; set; }
        public bool Status { get; set; }
    }
}
