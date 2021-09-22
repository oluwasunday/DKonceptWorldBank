using AbimMall.Data;
using AbimMall.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbimMall.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FeatureProducts = _productRepository.FeatureProduct
            };
            return View(homeViewModel);
        }
    }
}
