using System;
using System.Linq;

namespace AmazonProject.Models
{

    // THE REPOSITORY HELPS MANAGE THE DATABASE INFORMATION OUTSIDE OF THE HOMECONTROLLER
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
