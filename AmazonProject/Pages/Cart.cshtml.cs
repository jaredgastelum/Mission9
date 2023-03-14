using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AmazonProject.Models;
using AmazonProject.Infastructure;

namespace AmazonProject.Pages
{
    public class CartModel : PageModel
    {
        private IAmazonProjectRepository repo { get; set; }

        public CartModel (IAmazonProjectRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }

        public void OnGet()
        {
            // THIS WORKS WITH THE SESSION WE CREATED
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage();
        }

    }
}
