using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
using WebApplication2.Infrastructure;

namespace WebApplication2.Controllers
{
    public class CartController : Controller
    {
        private readonly DBAlcoholContext db;
        public CartController(DBAlcoholContext _db)
        {
            db = _db;
        }
        //public IActionResult Cart(string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    return View();
        //}
        public ActionResult Index()
        {
            if (Request.Query["retUrl"].ToString() != "")
            {
                ViewBag.continueBuy = Request.Query["retUrl"].ToString();
            }
            else
            {
                ViewBag.continueBuy = Request.Headers["Referer"].ToString();
            }
            ViewBag.contBuy = ViewBag.continueBuy;
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            if (curCart == null) curCart = new List<int[]>();
            List<CartItem> cart = new List<CartItem>();
            foreach (int[] i in curCart)
            {
                int curId = i[0];
                int curQty = i[1];
                CartItem cartItem = (from p in db.Product
                                     where int.Parse(p.ProductNo) == curId
                                     select
                                     new CartItem
                                     {

                                         ProductName = p.ProductName,
                                         Price = p.Price,
                                         qty = curQty,
                                         PicName = (from pr in db.Ppics where curId == int.Parse(pr.ProductNo) select pr.PicName).FirstOrDefault(),
                                     }).FirstOrDefault<CartItem>();
                cart.Add(cartItem);
            }
            List<ProductCat> productCats = new List<ProductCat>();
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
            ViewBag.cart = cart;
            ViewBag.productCats = productCats;
            return View("Cart");
        }
        public ActionResult AddCart(int id)
        {

            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            if (curCart == null)
                HttpContext.Session.SetJson("Cart", new List<int[]> { new int[] { id, 1 } });
            else
            {
                bool found = false;
                foreach (var p in curCart)
                {
                    if (p[0] == id)
                    {
                        found = true;
                        p[1] += 1;
                        break;
                    }
                }
                if (!found)
                {
                    curCart.Add(new int[] { id, 1 });
                }
                HttpContext.Session.SetJson("Cart", curCart);
            }
            return Index();
        }
        public RedirectResult updateCartRow(int id)
        {
            int value = int.Parse(Request.Query["value"].ToString());
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            curCart[id][1] = value;
            HttpContext.Session.SetJson("Cart", curCart);
            return Redirect("/Cart?retUrl=" + Request.Query["retUrl"].ToString());
        }
        public RedirectResult deleCartRow(int id)
        {
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            curCart.RemoveAt(id);
            HttpContext.Session.SetJson("Cart", curCart);
            return Redirect("/Cart?retUrl=" + Request.Query["retUrl"].ToString());
        }
        public RedirectResult storeCartRow(int id)
        {
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            HttpContext.Session.SetJson("Cart", curCart);
            return Redirect("/Cart?retUrl=" + Request.Query["retUrl"].ToString());
        }
    }
}