using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmazonProject.Controllers
{
    public class PaymentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View(new Payment());
        }
    }
}
