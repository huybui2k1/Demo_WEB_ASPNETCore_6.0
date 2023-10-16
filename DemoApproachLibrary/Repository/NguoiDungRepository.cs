using DemoApproachLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApproachLibrary.Repository
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        public IEnumerable<NguoiDungViewModel> GetNguoiDungs(string sortBy) => NguoiDungDao.Instance.GetNguoiDungList(sortBy);
        public IEnumerable<NguoiDungViewModel> GetNguoiDungByNames(string searchName, int userType, string sortBy) => NguoiDungDao.Instance.GetNguoiDungByNames(searchName, userType, sortBy);
    }
}
