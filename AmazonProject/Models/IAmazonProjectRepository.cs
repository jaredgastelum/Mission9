using System;
using System.Linq;

namespace AmazonProject.Models
{
    public interface IAmazonProjectRepository
    {
        IQueryable<Book> Books { get; }
    }
}
