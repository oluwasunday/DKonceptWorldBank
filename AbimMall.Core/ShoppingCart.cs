using AbimMall.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AbimMall.Models
{
    public class ShoppingCart
    {
        private readonly AbimMallDbContext _dbContext;
        public ShoppingCart(AbimMallDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    }
}
