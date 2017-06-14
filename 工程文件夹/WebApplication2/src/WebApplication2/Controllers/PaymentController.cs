using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Infrastructure;
using WebApplication2.Models;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2.Controllers
{
    public class PaymentController : Controller
    {
        private IHostingEnvironment host = null;
        private readonly DBAlcoholContext db;
        public PaymentController(DBAlcoholContext _db,IHostingEnvironment _host)
        {
            db = _db;
            host = _host;
        }
        public ActionResult Index()
        {
            string merId, amt, merTransId, transId, transTime;
            if (RemotePost.PaymentVerify(Request,host.WebRootPath, out merId, out amt, out merTransId, out transId, out transTime) && merId == "Team01")
            {
                ViewBag.paymentMsg = "付款成功！     付款号：" + merTransId.ToString() + "；   金额：" + amt.ToString() + "元。";//付款成功！显示付款信息作为测试。
                Payment payment = db.Payment.Single(m => m.ObjId == int.Parse(merTransId));
                
                    payment.PaymentState = 1;
                payment.Amount = double.Parse(amt);
                    db.SaveChanges();
                
                          }

            return View();
        }
    }
}