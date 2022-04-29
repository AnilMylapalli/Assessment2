using Ehealthcare.Entities;
using EHealthcare.Entities;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Members
        private readonly PMContext _context;

        private BaseRepository<Ehealthcare.Entities.Account> _accountRepository;
        private BaseRepository<Cart> _cartRepository;
        private BaseRepository<CartItem> _cartItemRepository;
        private BaseRepository<Category> _categoryRepository;
        private BaseRepository<Order> _orderRepository;
        private BaseRepository<Product> _productRepository;
        private BaseRepository<User> _userRepository;
        
        #endregion

        #region Constructors
        public UnitOfWork(PMContext dbContext)
        {
            _context = dbContext;

        }
        #endregion

        #region Public Repository Creation Properties


        /// <summary>
        /// Get/Set Property for AppFunction repository.
        /// </summary>

        public BaseRepository<Ehealthcare.Entities.Account> AccountRepository
        {
            get
            {
                if (this._accountRepository == null)
                    this._accountRepository = new BaseRepository<Ehealthcare.Entities.Account>(_context);
                return _accountRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for AppModule repository.
        /// </summary>
        public BaseRepository<Cart> CartRepository
        {
            get
            {
                if (this._cartRepository == null)
                    this._cartRepository = new BaseRepository<Cart>(_context);
                return _cartRepository;
            }
        }

        public BaseRepository<CartItem> CartItemRepository
        {
            get
            {
                if (this._cartItemRepository == null)
                    this._cartItemRepository = new BaseRepository<CartItem>(_context);
                return _cartItemRepository;
            }
        }

        public BaseRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new BaseRepository<Category>(_context);
                return _categoryRepository;
            }
        }

        public BaseRepository<Order> OrderRepository
        {
            get
            {
                if (this._orderRepository == null)
                    this._orderRepository = new BaseRepository<Order>(_context);
                return _orderRepository;
            }
        }

        public BaseRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new BaseRepository<Product>(_context);
                return _productRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Application repository.
        /// </summary>
        public BaseRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new BaseRepository<User>(_context);
                return _userRepository;
            }
        }

        public BaseRepository<Account> accountRepository => throw new NotImplementedException();

        public BaseRepository<Cart> cartRepository => throw new NotImplementedException();

        public BaseRepository<CartItem> cartItemRepository => throw new NotImplementedException();

        public BaseRepository<Category> categoryRepository => throw new NotImplementedException();

        public BaseRepository<Order> orderRepository => throw new NotImplementedException();

        public BaseRepository<Product> productRepository => throw new NotImplementedException();

        public BaseRepository<User> userRepository => throw new NotImplementedException();

        #endregion

        #region Public Methods
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();

        }

        /// <summary>
        /// Save method -- async.
        /// </summary>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


        #endregion

        #region Implementing IDiosposable

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
