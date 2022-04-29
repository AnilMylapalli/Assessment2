using EHealthcare.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public interface ICartItemDataService
    {
        Task<IEnumerable<CartItem>> Getallcartitems();
        Task<CartItem> GetcartbyID(int UserID);
    }
}
