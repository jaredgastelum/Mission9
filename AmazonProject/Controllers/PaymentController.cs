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
        private IPaymentRepository repo { get; set; }
        private Basket basket { get; set; }

        public PaymentController (IPaymentRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Payment());
        }

        [HttpPost]
        public IActionResult Checkout(Payment payment)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                payment.Lines = basket.Items.ToArray();
                repo.SavePayment(payment);
                basket.ClearBasket();

                return RedirectToPage("/PaymentCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
