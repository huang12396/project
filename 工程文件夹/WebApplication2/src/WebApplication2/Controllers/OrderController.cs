using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
       
            public IActionResult Order(string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }
    
}