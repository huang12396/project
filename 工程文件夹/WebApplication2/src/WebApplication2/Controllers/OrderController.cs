using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http;
using WebApplication2.Infrastructure;
using Newtonsoft.Json;


namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private readonly DBAlcoholContext db;
        public OrderController(DBAlcoholContext _db)
        {
            db = _db;
        }
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Request = Request;
            //string uid = User.Identity.Name;
            OrderViewModel ovm = new OrderViewModel();
            ovm.orders = new List<OrderInfo>();
            //ovm.receivers = new List<Consignee>();
            //ovm.words = new List<CustomerWords>();
            ovm.payment = new Payment();
            ////获取信息以显示在页面
            //ovm.curCustomer = db.Customer.Single(m => m.UserName == uid);
            ViewBag.payments = db.PaymentType.Where(m => m.ObjId > 0).ToArray<PaymentType>();
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            ovm.orderQty = 0;
            ovm.payment.Amount = 0.0;
            foreach (var OrdersItem in curCart)
            {
                int curQty = OrdersItem[1];
                ovm.orderQty += OrdersItem[1];
                int pObjId = OrdersItem[0];
                    //for (int i = 0; i < curCart.Count; i++)
                    //{
                        var product = db.Product.Single(m => int.Parse(m.ProductNo) == pObjId);
                            ovm.orders.Add(new OrderInfo
                            {
                                ProductNo = int.Parse(product.ProductNo),
                                price = (double)product.Price,
                                ProductName = product.ProductName,
                                qty = curQty,
                                PicName = (from pr in db.Ppics where pObjId == int.Parse(pr.ProductNo) select pr.PicName).FirstOrDefault(),
                            });
                            ovm.payment.Amount += (int)product.Price;
                        
                    //}
                
            }
            ViewBag.Orders = ovm;
            return View("Order", ovm);
        }
    }
    
}