using EHealthcare.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public interface IOrderDataService
    {
        void StoreOrderItems(List<Order> orders);
        Task<CartItem> GetOrderByOrderId(int OrderID);
    }
}
