using AbimMall.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AbimMall.Database
{
    public class AbimMallDbContext : DbContext
    {
        public AbimMallDbContext(DbContextOptions<AbimMallDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
