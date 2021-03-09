using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_Database.Models
{
    //define the characteristics for our cart model
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book bok, int qty)
        {
            CartLine line = Lines.Where(b => b.Book.BookId == bok.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bok,
                    Quantity = qty                    
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book bok) =>
            Lines.RemoveAll(x => x.Book.BookId == bok.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(e => Convert.ToDecimal((e.Book.Price)) * e.Quantity); //Price is hard coded

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
