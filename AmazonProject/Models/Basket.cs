﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonProject.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Book book, int qty)
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
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }

        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}
