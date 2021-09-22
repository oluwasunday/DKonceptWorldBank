using AbimMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbimMall.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FeatureProducts { get; set; } 
    }
}
