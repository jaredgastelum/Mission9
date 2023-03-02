using System;
using System.Linq;

namespace AmazonProject.Models
{
    public interface IAmazonProjectRepository
    {

        // THIS WILL WORK HAND AND HAND WITH THE EFAMAZONPROJECTREPOSITORY
        IQueryable<Book> Books { get; }
    }
}
