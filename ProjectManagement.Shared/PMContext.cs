using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ProjectManagement.Shared
{
    public class PMContext : DbContext
    {

        public PMContext()
        {
        }

        public PMContext(DbContextOptions<PMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ehealthcare.Entities.Account> AppAccount { get; set; }
        public virtual DbSet<Cart> AppCart { get; set; }
        public virtual DbSet<CartItem> AppItem { get; set; }
        public virtual DbSet<Category> AppCategory { get; set; }
        public virtual DbSet<Order> AppOrder { get; set; }
        public virtual DbSet<Product> AppProduct { get; set; }
        public virtual DbSet<User> AppUser { get; set; }
    }
}
