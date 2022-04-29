using EHealthcare.Entities;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
        BaseRepository<Ehealthcare.Entities.Account> accountRepository { get; }
        BaseRepository<Cart> cartRepository { get; }
        BaseRepository<CartItem> cartItemRepository { get; }
        BaseRepository<Category> categoryRepository { get; }
        BaseRepository<Order> orderRepository { get; }
        BaseRepository<Product> productRepository { get; }
        BaseRepository<User> userRepository { get; }
    }
}
