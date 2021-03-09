using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment5_Database.Models;
using Assignment5_Database.Infrastructure;

namespace Assignment5_Database.Pages
{
    //this is the razor page helps us build the cart
    public class DonateModel : PageModel
    {
        private BookRepository repository;

        //Constructor
        public DonateModel(BookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        //public void OnGet(string returnUrl)
        //{
        //    ReturnUrl = returnUrl ?? "/";
        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        //}

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        //public IActionResult OnPost(long bookId, string returnUrl)
        //{
        //    Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        //    Cart.AddItem(book, 1);
        //    HttpContext.Session.SetJson("cart", Cart);
        //    return RedirectToPage(new { returnUrl = returnUrl });
        //}

        //creating add items

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.BookId == bookId);
            Cart.AddItem(book, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //create remove items from cart
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
