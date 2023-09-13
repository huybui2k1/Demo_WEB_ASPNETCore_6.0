

using DemoApproachLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApproachLibrary.Repository
{
    public interface IKhachHangRepository
    {

        IEnumerable<KhachHang> GetKhachHangs(string sortBy);
        IEnumerable<KhachHang> GetKhachHangByName(string name, string CityName, string sortBy);
        KhachHang GetKhachHangByID(int id);
        void InsertKhachHang(KhachHang kh);
        void UpdateKhachHang(KhachHang kh);
        void DeleteKhachHang(int id);
        IEnumerable<KhachHang> DeleteSelectedKhachHang(IEnumerable<int> DeleteList);
    }
}
