using Ehealthcare.Entities;
using EHealthcare.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjectManagement.Data
{
    [ExcludeFromCodeCoverage]
    public class AccountService : IAccountService
    {
        #region "Variables"
        public IBaseRepository<Account> AccountRepository { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public AccountService(IBaseRepository<Account> accountRepository, IUnitOfWork unitofWork)
        {
            this.AccountRepository = accountRepository;
            _unitOfWork = unitofWork;
        }

        public List<Account> GetEnities(int UserID)
        {
            IEnumerable<Account> appFunction = this._unitOfWork.accountRepository.Get();

            List<Account> appFunctionEntity = new List<Account>();
            foreach (var em in appFunction)
            {
                Account emEntity = new Account();
                emEntity.AccNumber = em.AccNumber;
                emEntity.Amount = em.Amount;
                emEntity.Email = em.Email;
                emEntity.ID = em.ID;
                emEntity.user = new User();
                emEntity.user.ID = em.user.ID;
                appFunctionEntity.Add(emEntity);

            }
            return appFunctionEntity;
        }
    }
}
