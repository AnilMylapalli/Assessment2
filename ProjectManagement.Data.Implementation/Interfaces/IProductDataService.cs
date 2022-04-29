using EHealthcare.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public interface IProductDataService
    {
        int AddProduct(Product entity);
        void EditProduct(Product entity);
        Task<IEnumerable<User>> GetallProdcut();
        Task<Product> GetProductByCategory(int CategoryID);
    }
}
