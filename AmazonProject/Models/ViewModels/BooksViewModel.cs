using System;
using System.Linq;

namespace AmazonProject.Models.ViewModels
{
    public class BooksViewModel
    {

        // IQueryable is a type of variable that allows us to pass the list of books with all of their information and order it
        public IQueryable<Book> Books { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}

