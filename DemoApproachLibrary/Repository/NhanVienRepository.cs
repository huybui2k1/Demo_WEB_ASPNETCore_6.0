
using DemoApproachLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApproachLibrary.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {

        public IEnumerable<NhanVien> GetNhanViens(string sortBy) => NhanVienDao.Instance.GetNhanVienList(sortBy);
        public IEnumerable<NhanVien> GetNhanVienByName(string name, string sortBy) => NhanVienDao.Instance.GetNhanVienBySearchName(name, sortBy);
        public NhanVien GetNhanVienByID(int id) => NhanVienDao.Instance.GetNhanVienByID(id);
        public void InsertNhanVien(NhanVien kh) => NhanVienDao.Instance.AddNew(kh);
        public void UpdateNhanVien(NhanVien kh) => NhanVienDao.Instance.Update(kh);
        public void DeleteNhanVien(int id) => NhanVienDao.Instance.Remove(id);
        public IEnumerable<NhanVien> DeleteSelectedNhanVien(IEnumerable<int> DeleteList) => NhanVienDao.Instance.RemoveNhanVienSelected(DeleteList);
    }
}
