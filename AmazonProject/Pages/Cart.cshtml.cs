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

        // CREATING A BASKET INSTANCE
        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }

        public CartModel (IAmazonProjectRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
          
        }


        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            
            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage ( new {ReturnUrl = returnUrl});
        }
    }
}
