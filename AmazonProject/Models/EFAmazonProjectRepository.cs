using System;
using System.Linq;

namespace AmazonProject.Models
{
    public class EFAmazonProjectRepository : IAmazonProjectRepository
    {
        private BookstoreContext context { get; set; }

        public EFAmazonProjectRepository (BookstoreContext temp)
        {
            context = temp;
        }


        public IQueryable<Book> Books => context.Books;
    }
}
