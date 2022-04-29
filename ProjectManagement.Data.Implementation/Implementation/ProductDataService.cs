using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectManagement.Data
{
    public class ProductDataService : IProductDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductDataService(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public int AddProduct(Product entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Product prd = new Product()
                {
                    Name = entity.Name,
                    Price = entity.Price,
                    Quantity = entity.Quantity,
                    Uses = entity.Uses,
                    CagtegoryID = entity.CagtegoryID
                };
                _unitOfWork.productRepository.Insert(prd);
                _unitOfWork.Save();
            }
            return 1;
        }

        public void EditProduct(Product entity)
        {
            _unitOfWork.productRepository.Update(entity);
        }

        public async Task<IEnumerable<Product>> GetallProdcut()
        {
            return await _unitOfWork.productRepository.DbSet.Select(x => x).ToListAsync();
        }

        public async Task<Product> GetProductByCategory(int CategoryID)
        {
            return await _unitOfWork
                .productRepository
                .DbSet
                .Where(x => x.ID == CategoryID)
                .Select(x => new Product { ID = x.ID, Name = x.Name, CompanyName = x.CompanyName , Price = x.Price , Uses = x.Uses , Quantity =x.Quantity })
                .FirstOrDefaultAsync();
        }

        Task<IEnumerable<User>> IProductDataService.GetallProdcut()
        {
            throw new NotImplementedException();
        }
    }
}
