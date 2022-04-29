using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public class CartItemDataService : ICartItemDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartItemDataService(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public async Task<IEnumerable<CartItem>> Getallcartitems()
        {
            return await _unitOfWork.cartItemRepository.DbSet.Select(x => x).ToListAsync();
        }

        public async Task<CartItem> GetcartbyID(int UserID)
        {
            return await _unitOfWork
                .cartItemRepository
                .DbSet
                .Where(x => x.ID == UserID)
                .Select(x => new CartItem { ID = x.ID, Product = x.Product , ProductID = x.ProductID , CartID = x.CartID})
                .FirstOrDefaultAsync();
        }
    }
}
