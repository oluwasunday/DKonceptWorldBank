using AbimMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbimMall.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products(string categoryName);
        IEnumerable<Product> FeatureProduct { get;}
        Product GetProductById(string productId);
        IEnumerable<Product> GetProductByCategoryName(string categoryName);
    }
}
