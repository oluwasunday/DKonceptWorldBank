using AbimMall.Data;
using AbimMall.Database;
using AbimMall.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbimMall.Core
{
    public class ProductRepository : IProductRepository
    {
        private readonly AbimMallDbContext _dbContext;
        public ProductRepository(AbimMallDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public IEnumerable<Product> Products(string categoryName)
        {
            IEnumerable<Product> products;
            if (categoryName == null)
            {
                products = _dbContext.Products.Include(prod => prod.Category).ToList();
            }
            else
            {
                products = _dbContext.Products.Include(prod => prod.Category)
                    .Where(x => x.Category.CategoryName == categoryName).ToList();
            }
            return products;
        }

        public IEnumerable<Product> FeatureProduct
        {
            get => _dbContext.Products.Where(x => x.IsFeature == true);
        }
        

        public Product GetProductById(string productId)
        {
            return _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public IEnumerable<Product> GetProductByCategoryName(string categoryName)
        {
            return _dbContext.Products
                .Include(x => x.Category)
                .Where(y => y.Category.CategoryName == categoryName);
        }
    }
}
