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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AbimMallDbContext _dbContext;
        public CategoryRepository(AbimMallDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Category> Categories()
        {
            IEnumerable<Category> categories = _dbContext.Categories.ToList();
            return categories;
        }

        public Category GetCategory(string categoryName)
        {
            Category category = _dbContext.Categories.Include(cat => cat.Products).FirstOrDefault(cat => cat.CategoryName == categoryName);
            return category;
        }
    }
}
