using AbimMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbimMall.Core
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories();
        public Category GetCategory(string categoryName);
    }
}
