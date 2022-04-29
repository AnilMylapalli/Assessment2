using Ehealthcare.Entities;
using System.Collections.Generic;


namespace ProjectManagement.Data
{
    public interface IAccountService
    {
        List<Account> GetEnities(int UserID);
    }
}
