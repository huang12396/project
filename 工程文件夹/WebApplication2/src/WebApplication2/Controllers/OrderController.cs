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
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly DBAlcoholContext db;
        public OrderController(DBAlcoholContext _db)
        {
            db = _db;
        }
        static decimal amount = 0;
        static int id;
        [Authorize]
        public ActionResult Index()
        {
            amount = 0;
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

            EntityEntry<Payment> d = db.Payment.Add(new Payment());
            DateTime da = DateTime.Now;
            d.Entity.TransTime = da;
            db.SaveChanges();

            var get = db.Payment.Single(m => m.TransTime == da);
            id = get.ObjId;

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
                    realprice = curQty * (double)product.Price,
                    PicName = (from pr in db.Ppics where pObjId == int.Parse(pr.ProductNo) select pr.PicName).FirstOrDefault(),

                });
                ovm.payment.Amount += (curQty * (double)product.Price);
                EntityEntry<Orders> o = db.Orders.Add(new Orders());

                o.Entity.ProductNo = product.ProductName;
                o.Entity.OrderId = id.ToString();
                o.Entity.PaymentNo = id;
                o.Entity.OrderState = "0";
                o.Entity.Amt = (double)product.Price;
                o.Entity.OrderAddress = User.Identity.Name;
                db.SaveChanges();
                //}
                amount += product.Price;

            }
            ViewBag.Orders = ovm;
            return View("Order", ovm);
        }

        [HttpPost]
        public ActionResult Index(OrderViewModel ovm)
        {
            bool succeed = true;
            int payId = 0;
            int curZip;
            EntityEntry<Payment> p = db.Payment.Add(new Payment());
            p.Entity.PaymentState = 0;


            payId = p.Entity.ObjId;
            PayRequestInfo pri = new PayRequestInfo();
            pri.Amt = amount.ToString();
            pri.MerId = "Team01";
            pri.MerTransId = id.ToString();
            pri.PaymentTypeObjId = Request.Form["paymentType"];
            pri.PostUrl = "http://payportal.chinacloudsites.cn";
            pri.ReturnUrl = "http://" + Request.Host + Url.Action("Index", "Payment");
            pri.CheckValue = RemotePost.getCheckValue(pri.MerId, pri.ReturnUrl, pri.PaymentTypeObjId, pri.Amt, pri.MerTransId);
            return View("PayRequest", pri);
        }
      

    }
}