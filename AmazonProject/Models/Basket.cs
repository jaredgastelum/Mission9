using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonProject.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();


        // ADDING ITEMS TO THE BASKET LINE
        public virtual void AddItem (Book book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }

        }

        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        // CALCULATE THE TOTAL COST FOR ALL THE BOOKS
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    // INFORMATION WE WANT IN THE BASKET LINE
    public class BasketLineItem
    {
        public int LineID { get; set; }

        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}

