using EHealthcare.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public interface IUserDataService
    {
        Task<IEnumerable<User>> GetallUsers();
        Task<User> GetUserbyID(int UserID);
    }
}
