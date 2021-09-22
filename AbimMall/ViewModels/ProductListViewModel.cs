using AbimMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbimMall.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentProduct { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> ProductByCategoryName { get; set; }
    }
}
