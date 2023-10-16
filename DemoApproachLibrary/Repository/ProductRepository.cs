using DemoApproachLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApproachLibrary.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<HangHoa> GetProducts(string sortBy) => ProductDao.Instance.GetProductList(sortBy);
        public IEnumerable<HangHoa> GetProductByName(string name, string sortBy) => ProductDao.Instance.GetProductBySearchName(name, sortBy);

        public HangHoa GetProductByID(int id) => ProductDao.Instance.GetProductByID(id);
        public void InsertProduct(HangHoa hh) => ProductDao.Instance.AddNew(hh);
        public void UpdateProduct(HangHoa hh) => ProductDao.Instance.Update(hh);
        public void DeleteProduct(int id) => ProductDao.Instance.Remove(id);
    }
}
