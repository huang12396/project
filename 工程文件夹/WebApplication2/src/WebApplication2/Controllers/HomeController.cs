using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBAlcoholContext db;

        public HomeController(DBAlcoholContext alcoholdb)
        {
            db = alcoholdb;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "主页";

            HomeIndexViewModel ivm = new HomeIndexViewModel();
            ivm.recProducts = new List<ProductList>();
            ivm.disProducts = new List<ProductList>();
            ivm.productCats = new List<ProductCat>();

            //获取推荐商品(4种)
            var recProducts = db.Product.Where<Product>(m => m.ProductId > 001).OrderBy<Product, float>(m => (float)m.Price).Take<Product>(4);
            foreach(var p in recProducts)
            {
                ProductList pl = new ProductList();
                pl.p = new Product { ProductId = p.ProductId, ProductName = p.ProductName, Price = p.Price };
                ivm.recProducts.Add(pl);
            }
            return View(ivm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Detail(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
    }
}
