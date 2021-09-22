using AbimMall.Core;
using AbimMall.Data;
using AbimMall.Models;
using AbimMall.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbimMall.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this._categoryRepository = categoryRepository;
            this._productRepository = productRepository;
        }


        public ViewResult List(string categoryName)
        {
            IEnumerable<Product> products = _productRepository.Products(categoryName);

            IEnumerable<Category> categories = _categoryRepository.Categories();
            ViewData["products"] = products;
            ViewData["categories"] = categories;
            return View();
        }


        [HttpGet]
        public ActionResult ProductDetails(string id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }


        [HttpPost]
        public ActionResult ProductByCategoryName(string categoryName)
        {
            Category category = _categoryRepository.GetCategory(categoryName);
            IEnumerable<Category> categories = _categoryRepository.Categories();

            ViewData["categories"] = categories;
            ViewData["category"] = category;
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
