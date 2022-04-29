using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectManagement.Data
{
    public class UserDataService : IUserDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserDataService()
        {
        }

        public async Task<IEnumerable<User>> GetallUsers()
        {
            return await _unitOfWork.userRepository.DbSet.ToListAsync();
        }

        public async Task<User> GetUserbyID(int UserID)
        {
            return await _unitOfWork
                .userRepository
                .DbSet
                .Where(x => x.ID == UserID)
                .Select(x => new User { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName })
                .FirstOrDefaultAsync();
        }

        public int CreateUser(User user)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                User user1 = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    IsAdmin = user.IsAdmin,
                    DateOfBirth = System.DateTime.Now,
                    Email = user.Email,
                    Password = user.FirstName,
                    Phone = Convert.ToString(System.DateTime.Now.Second)
                };
                _unitOfWork.userRepository.Insert(user1);
                _unitOfWork.Save();
            }
            return 1;

        }

        public void UpdateUserAsync(User user)
        {
           _unitOfWork.userRepository.Update(user);
        }
    }
}
