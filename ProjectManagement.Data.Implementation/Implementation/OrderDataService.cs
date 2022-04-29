using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectManagement.Data
{
    public class OrderDataService : IOrderDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void StoreOrderItems(List<Order> orders)
        {
            foreach (var item in orders)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _unitOfWork.orderRepository.Insert(item);
                    _unitOfWork.Save();
                }
            }
        }

        public async Task<Order> GetOrderByOrderId(int OrderID)
        {
            return await _unitOfWork
                .orderRepository
                .DbSet
                .Where(x => x.ID == OrderID)
                .Select(x => new Order { ID = x.ID, UserID = x.UserID, CartID = x.CartID })
                .FirstOrDefaultAsync();
        }

        Task<CartItem> IOrderDataService.GetOrderByOrderId(int OrderID)
        {
            throw new System.NotImplementedException();
        }
    }
}
