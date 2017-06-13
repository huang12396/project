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
            ViewBag.news = new[] { "白酒的分类","葡萄酒怎么喝","洋酒的储藏方法", "用啤酒做菜" };

            HomeIndexViewModel ivm = new HomeIndexViewModel();
            ivm.recProducts = new List<ProductList>();
            ivm.disProducts = new List<ProductList>();
            ivm.productCats = new List<ProductCat>();

            //分类
            foreach (var pt in db.ProductClassification.Where<ProductClassification>(m => m.ObjId > 0).GroupBy<ProductClassification, string>(m => m.Classification))
            {
                ProductCat pc = new ProductCat();
                pc.typeName = pt.Key;
                pc.types = new List<ProductClassification>();
                foreach (var p in pt)
                {
                    pc.types.Add(new ProductClassification { ObjId = p.ObjId, Classification = p.Classification, Cname = p.Cname });
                }
                ivm.productCats.Add(pc);
            }

            //获取推荐商品(4种)
            var recProducts = db.Product.Where<Product>(m => m.ProductId > 001).OrderBy<Product, string>(m => (string)m.ProductName).Take<Product>(4);
            foreach (var p in recProducts)
            {
                ProductList pl = new ProductList();
                pl.p = new Product { ProductNo = p.ProductNo, ProductName = p.ProductName, Price = p.Price, };
                pl.pn = db.Ppics.Where<Ppics>(m => m.ProductNo == p.ProductNo).First<Ppics>();

                ivm.recProducts.Add(pl);
            }

            //获取优惠商品(6种)
            var disProducts = db.Product.Where<Product>(m => m.ProductId > 001).OrderBy<Product, float>(m => (float)m.Price).Take<Product>(6);
            foreach (var p in disProducts)
            {
                ProductList pl = new ProductList();
                pl.p = new Product { ProductNo = p.ProductNo, ProductName = p.ProductName, Price = p.Price };
                pl.pn = db.Ppics.Where<Ppics>(m => m.ProductNo == p.ProductNo).First<Ppics>();

                ivm.disProducts.Add(pl);
            }
            return View(ivm);
        }

        public IActionResult Catalog(int typeId, string typeName)
        {
            ViewBag.catalogName = typeName;
            List<ProductCat> productCats = new List<ProductCat>();
            List<ProductList> recProducts = new List<ProductList>();
            foreach (var pt in db.ProductClassification.Where<ProductClassification>(m => m.ObjId > 0).GroupBy<ProductClassification, string>(m => m.Classification))
            {
                ProductCat pc = new ProductCat();
                pc.typeName = pt.Key;
                pc.types = new List<ProductClassification>();
                foreach (var p in pt)
                {
                    pc.types.Add(new ProductClassification { ObjId = p.ObjId, Classification = p.Classification, Cname = p.Cname });
                }
                productCats.Add(pc);
            }
            var products = from p in db.Product where p.ProductId>0 && (from t in db.ProductClassify where t.ItsType == typeId select t.ProductNo).Contains(p.ProductNo) select p;
            foreach (var p in products)
            {   
                ProductList pl = new ProductList();
                pl.p = new Product { ProductNo = p.ProductNo, ProductName = p.ProductName, Price = p.Price };
                pl.pn = db.Ppics.Where<Ppics>(m => m.ProductNo == p.ProductNo).First<Ppics>();
                recProducts.Add(pl);
            }
            ViewBag.productCats = productCats;
            ViewBag.catProducts = recProducts;
            return View();
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

        public IActionResult Detail(String PNo)
        {
            ProductDtl pd = new ProductDtl();
            pd.p = db.Product.Where<Product>(m => m.ProductNo == PNo).First<Product>();
            pd.productpics = db.Ppics.Where<Ppics>(m => m.ProductNo == PNo && m.PicType == "1");
            pd.pnd = db.Ppics.Where<Ppics>(m => m.ProductNo == PNo && m.PicType == "2").First<Ppics>();
            pd.pdtl = db.Pdetail.Where<Pdetail>(m => m.ProductNo == PNo).First<Pdetail>();
            return View(pd);
        }
    }
}
