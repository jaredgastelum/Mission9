using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AmazonProject.Models;
using AmazonProject.Models.ViewModels;

namespace AmazonProject.Controllers
{
    public class HomeController : Controller
    {

        private IAmazonProjectRepository repo;

        public HomeController (IAmazonProjectRepository temp)
        {
            repo = temp;
        }

        // the INDEX.html is the book list screen
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            // This is how we print off the information for each book
            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }


        // this is from the set up. We can change this to something else later
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
